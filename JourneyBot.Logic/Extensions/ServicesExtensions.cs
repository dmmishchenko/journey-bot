using JourneyBot.Logic.Interfaces;
using JourneyBot.Logic.Services;
using JourneyBot.Logic.Services.JourneyBot;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyBot.Logic.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<IJourneyBotMessagesService, JourneyBotMessagesService>();
            services.AddScoped<IMessageRenderer, TelegramMessageRenderer>();

            return services;
        }
    }
}
