
using BS.Catalogo.API.Data;
using BS.Catalogo.API.Data.Repository;
using BS.Catalogo.API.Models;

namespace BS.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}