using BS.MessageBus;
using BS.Core.Utils;

namespace BS.Identidade.API.Configuration
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
