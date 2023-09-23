using Journey.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Journey.Common.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TelegramBotSettings>(configuration.GetSection(nameof(TelegramBotSettings)));

            return services;
        }
    }
}
