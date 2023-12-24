
using BS.Clientes.API.Application.Commands;
using BS.Clientes.API.Application.Events;
using BS.Clientes.API.Data;
using BS.Clientes.API.Models;
using BS.Core.Mediator;
using FluentValidation.Results;
using MediatR;

namespace NSE.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}