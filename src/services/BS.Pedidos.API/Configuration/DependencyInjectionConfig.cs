using BS.Core.Mediator;
using BS.Pedidos.Application.Queries;
using BS.Pedidos.Domain.Vouchers;
using BS.Pedidos.Infra.Data;
using BS.Pedidos.Infra.Data.Repositories;
using BS.WebAPI.Core.Usuario;

namespace BS.Pedidos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();

            // Data 
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidosContext>();
        }
    }
}