using BS.Core.Mediator;
using BS.Pedidos.Infra.Data;

namespace BS.Pedidos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<PedidosContext>();

        }
    }
}