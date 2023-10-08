using Journey.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Journey.Common.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TelegramBotSettings>(configuration.GetSection(nameof(TelegramBotSettings)));
            services.Configure<TelegramReceiverSettings>(configuration.GetSection(nameof(TelegramReceiverSettings)));

            return services;
        }

        public static T GetConfiguration<T>(this IServiceProvider serviceProvider) where T : class
        {
            var service = serviceProvider.GetService<IOptions<T>>();
            if (service is null)
                throw new ArgumentNullException(nameof(T));

            return service.Value;
        }
    }
}
