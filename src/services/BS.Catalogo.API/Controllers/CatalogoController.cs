using BS.Catalogo.API.Models;
using BS.WebAPI.Core.Controllers;
using BS.WebAPI.Core.Identidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BS.Catalogo.API.Controllers
{
    [ApiController]
    public class CatalogoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [AllowAnonymous]
        [HttpGet("catalogo/produtos")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }

        [ClaimsAuthorize("Catalogo", "Ler")]
        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

        [HttpPost("catalogo/produtos")]
        public async Task<IActionResult> Adicionar(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
            await _produtoRepository.UnitOfWork.Commit();
            return Ok();
        }

        [HttpPut("catalogo/produtos/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, Produto produto)
        {
            var produtoAtual = await _produtoRepository.ObterPorId(id);
            if (produtoAtual == null) return NotFound();
            produtoAtual.Nome = produto.Nome;
            produtoAtual.Descricao = produto.Descricao;
            produtoAtual.Ativo = produto.Ativo;
            produtoAtual.Valor = produto.Valor;
            produtoAtual.DataCadastro = produto.DataCadastro;
            produtoAtual.Imagem = produto.Imagem;
            produtoAtual.QuantidadeEstoque = produto.QuantidadeEstoque;
            _produtoRepository.Atualizar(produtoAtual);
            await _produtoRepository.UnitOfWork.Commit();
            return Ok();
        }
    }
}
