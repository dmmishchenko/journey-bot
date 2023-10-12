using Journey.Common.Extensions;
using Journey.Common.Settings;
using Journey.TelegramBot.Polling.Handlers;
using Journey.TelegramBot.Polling.Listeners;
using Journey.TelegramBot.Polling.Strategy;
using Journey.TelegramBot.Strategies;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace Journey.TelegramBot.Polling.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddTelegramBotPolling(this IServiceCollection services)
        {
            services.AddHttpClient("telegram_bot_client")
                .AddTypedClient<ITelegramBotClient>((HttpClient httpClient, IServiceProvider sp) =>
                {
                    TelegramBotSettings botConfig = sp.GetConfiguration<TelegramBotSettings>();
                    TelegramBotClientOptions options = new TelegramBotClientOptions(botConfig.Token);//TODO: more complex init process!
                    return new TelegramBotClient(options, httpClient);
                });

            services.AddScoped<IUpdateHandler, PollingUpdateHandler>();
            services.AddScoped<ITelegramPollingListener, TelegramPollingListener>();
            services.AddScoped<IBotStrategy, PollingStrategy>();

            return services;
        }
    }
}
