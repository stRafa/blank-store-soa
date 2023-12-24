using BS.WebAPI.Core.Identidade;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace BS.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            return services;
        }

        public static WebApplication UseApiConfiguration(this WebApplication app)
        {
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture),
                SupportedCultures = new List<CultureInfo> { CultureInfo.InvariantCulture },
                SupportedUICultures = new List<CultureInfo> { CultureInfo.InvariantCulture }
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthConfiguration();

            app.MapControllers();

            return app;
        }
    }
}
