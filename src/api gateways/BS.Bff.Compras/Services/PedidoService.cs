using BS.Compras.BFF.Extensions;
using BS.Compras.BFF.Interfaces;
using BS.Compras.BFF.Models;
using Microsoft.Extensions.Options;
using System.Net;

namespace BS.Compras.BFF.Services
{
    public class PedidoService : Service, IPedidoService
    {
        private readonly HttpClient _httpClient;

        public PedidoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PedidoUrl);
        }

        public async Task<VoucherDTO> ObterVoucherPorCodigo(string codigo)
        {
            var response = await _httpClient.GetAsync($"/voucher/{codigo}/");

            if (response.StatusCode == HttpStatusCode.OK) return null;

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<VoucherDTO>(response);
        }
    }
}
