﻿using BS.Compras.BFF.Extensions;
using BS.Compras.BFF.Interfaces;
using Microsoft.Extensions.Options;

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
    }
}
