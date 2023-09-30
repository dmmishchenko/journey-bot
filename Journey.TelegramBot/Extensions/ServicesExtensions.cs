using Journey.TelegramBot.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Journey.TelegramBot.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBotManagers(this IServiceCollection services)
        {
            services.AddSingleton<IBotSettingsManager, BotSettingsManager>();
            services.AddSingleton<IBotStrategyManager, BotStrategyManager>();

            return services;
        }
    }
}
