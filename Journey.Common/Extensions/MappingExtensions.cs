using AutoMapper;
using Journey.Common.Settings;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Polling;

namespace Journey.Common.Extensions
{
    public static class MappingExtensions
    {
        public static IServiceCollection AddTelegramMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TelegramBotMapping));

            return services;
        }
    }

    public class TelegramBotMapping : Profile
    {
        public TelegramBotMapping()
        {
            CreateMap<TelegramBotSettings, ReceiverOptions>();
        }
    }

}
