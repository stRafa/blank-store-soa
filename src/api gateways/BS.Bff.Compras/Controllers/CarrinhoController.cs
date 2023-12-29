using BS.Compras.BFF.Interfaces;
using BS.Compras.BFF.Models;
using BS.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BS.Compras.BFF.Controllers
{
    [Route("api/compras/[controller]")]
    public class CarrinhoController : MainController
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly ICatalogoService _catalogoService;
        private readonly IPedidoService pedidoService;

        public CarrinhoController(ICarrinhoService carrinhoService, ICatalogoService catalogoService, IPedidoService pedidoService)
        {
            _carrinhoService = carrinhoService;
            _catalogoService = catalogoService;
            this.pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterCarrinho()
        {
            return CustomResponse(await _carrinhoService.ObterCarrinho());
        }

        [HttpGet("quantidade-itens")]
        public async Task<int> ObterQuantidadeCarrinho()
        {
            var quantidade = await _carrinhoService.ObterCarrinho();
            return quantidade?.Itens.Sum(i => i.Quantidade) ?? 0;
        }

        [HttpPost]
        [Route("itens")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinhoDTO itemProduto)
        {
            var produto = await _catalogoService.ObterPorId(itemProduto.ProdutoId);

            await ValidarItemCarrinho(produto, itemProduto.Quantidade);
            if (!OperacaoValida()) return CustomResponse();

            itemProduto.Nome = produto.Nome;
            itemProduto.Valor = produto.Valor;
            itemProduto.Imagem = produto.Imagem;

            var resposta = await _carrinhoService.AdicionarItemCarrinho(itemProduto);

            return CustomResponse(resposta);
        }

        [HttpPut]
        [Route("itens/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDTO itemProduto)
        {
            var produto = await _catalogoService.ObterPorId(produtoId);

            await ValidarItemCarrinho(produto, itemProduto.Quantidade);
            if (!OperacaoValida()) return CustomResponse();

            var resposta = await _carrinhoService.AtualizarItemCarrinho(produtoId, itemProduto);

            return CustomResponse(resposta);
        }

        [HttpDelete]
        [Route("itens/{produtoId}")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var produto = await _catalogoService.ObterPorId(produtoId);

            if (produto == null)
            {
                AdicionarErroProcessamento("Produto inexistente!");
                return CustomResponse();
            }

            var resposta = await _carrinhoService.RemoverItemCarrinho(produtoId);

            return CustomResponse(resposta);
        }

        [HttpPost("aplicar-voucher")]
        public async Task<IActionResult> AplicarVoucher([FromBody] string voucherCodigo)
        {
            var voucher = await pedidoService.ObterVoucherPorCodigo(voucherCodigo);

            if (voucher is null)
            {
                AdicionarErroProcessamento("Voucher inválido ou não encontrado!");
                return CustomResponse();
            }

            var resposta = await _carrinhoService.AplicarVoucherCarrinho(voucher);

            return CustomResponse(resposta);
        }


        private async Task ValidarItemCarrinho(ItemProdutoDTO produto, int quantidade)
        {
            if (produto == null) AdicionarErroProcessamento("Produto inexistente!");

            if (quantidade < 1) AdicionarErroProcessamento($"Escolha ao menos uma unidade do produto {produto.Nome}");

            var carrinho = await _carrinhoService.ObterCarrinho();

            var itemCarrinho = carrinho.Itens.FirstOrDefault(p => p.ProdutoId == produto.Id);

            if (itemCarrinho != null && itemCarrinho.Quantidade + quantidade > produto.QuantidadeEstoque)
            {
                AdicionarErroProcessamento($"O produto {produto.Nome} possui {produto.QuantidadeEstoque} unidades em estoque, você selecionou {quantidade}");
                return;
            }

            if (quantidade > produto.QuantidadeEstoque)
                AdicionarErroProcessamento($"O produto {produto.Nome} possui {produto.QuantidadeEstoque} unidades em estoque, você selecionou {quantidade}");
        }
    }
}
