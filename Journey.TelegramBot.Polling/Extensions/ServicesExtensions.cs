﻿using Journey.Common.Extensions;
using Journey.Common.Settings;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

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

            return services;
        }
    }
}