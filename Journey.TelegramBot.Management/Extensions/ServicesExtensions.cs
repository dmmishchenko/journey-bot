using Journey.TelegramBot.Management.Managers;
using Journey.TelegramBot.Management.Strategies;
using Journey.TelegramBot.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Journey.TelegramBot.Management.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBotManagers(this IServiceCollection services)
        {
            services.AddSingleton<IBotSettingsManager, BotSettingsManager>();
            services.AddSingleton<IBotStrategyManager, BotStrategyManager>();
            services.AddScoped<PollingStrategy>();

            return services;
        }
    }
}
