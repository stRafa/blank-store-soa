﻿using Microsoft.Extensions.DependencyInjection;

namespace BS.MessageBus
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException(nameof(connection));

            services.AddSingleton<IMessageBus>(new MessageBus(connection));

            return services;
        }
    }
}
