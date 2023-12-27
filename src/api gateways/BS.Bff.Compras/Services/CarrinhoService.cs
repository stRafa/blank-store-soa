using BS.Compras.BFF.Extensions;
using BS.Compras.BFF.Interfaces;
using BS.Compras.BFF.Models;
using BS.Core.Communication;
using Microsoft.Extensions.Options;

namespace BS.Compras.BFF.Services
{
    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }

        public async Task<CarrinhoDTO> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/carrinho/");
            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoDTO>(response);
        }

        public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDTO produto)
        {
            var response = await _httpClient.PostAsync("/carrinho/", ObterConteudo(produto));
            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDTO produto)
        {
            var response = await _httpClient.PutAsync($"/carrinho/{produto.ProdutoId}", ObterConteudo(produto));
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/carrinho/{produtoId}");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}
