using BS.Compras.BFF.Extensions;
using BS.Compras.BFF.Interfaces;
using Microsoft.Extensions.Options;

namespace BS.Compras.BFF.Services
{
    public class PagamentoService : Service, IPagamentoService
    {
        private readonly HttpClient _httpClient;

        public PagamentoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PagamentoUrl);
        }
    }
}
