using Journey.Common.Settings;
using Journey.TelegramBot.Polling.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace Journey.TelegramBot.Polling.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddTelegramBotPolling(this IServiceCollection services, IConfiguration configuration, string token)
        {
            services.AddHttpClient<ITelegramBotClient>((httpClient, sp) =>
            {
                var botConfig = services.Configure<TelegramBotSettings>();
                TelegramBotClientOptions options = new TelegramBotClientOptions(botConfig.BotToken);
                return new TelegramBotClient(options, httpClient);
            });
            services.AddSingleton<JourneyTelegramClient>();
            services.AddHttpClient<JourneyTelegramClient>();

            return services;
        }
    }
}
