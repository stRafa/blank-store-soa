﻿using BS.Compras.BFF.Extensions;
using BS.Compras.BFF.Interfaces;
using BS.Compras.BFF.Models;
using Microsoft.Extensions.Options;

namespace BS.Compras.BFF.Services
{
    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }

        public async Task<ItemProdutoDTO> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");
            TratarErrosResponse(response);
            return await DeserializarObjetoResponse<ItemProdutoDTO>(response);
        }
    }
}
