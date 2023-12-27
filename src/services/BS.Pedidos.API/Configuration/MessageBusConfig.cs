using BS.Core.Utils;
using BS.MessageBus;

namespace BS.Pedidos.API.Configuration
{
    public static class MessageBusConfig
    {
        public static IServiceCollection AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));

            return services;
        }
    }
}
