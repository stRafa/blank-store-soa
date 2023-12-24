using BS.Clientes.API.Services;
using BS.Core.Utils;
using BS.MessageBus;

namespace BS.Clientes.API.Configuration
{
    public static class MessageBusConfig
    {
        public static IServiceCollection AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistroClienteIntegrationHandler>();

            return services;
        }
    }
}
