using Hangfire;
using Hangfire.PostgreSql;
using Journey.Common.Settings;
using JourneyBot.Logic.Interfaces;
using JourneyBot.Logic.Services;
using JourneyBot.Logic.Services.JourneyBot;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyBot.Logic.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJourneyBotMessagesService, JourneyBotMessagesService>();
            services.AddScoped<IMessageRenderer, TelegramMessageRenderer>();

            string hangfireConn = configuration.GetConnectionString("HangfireConnection");
            services.AddHangfire(config => config.UsePostgreSqlStorage(v => v.UseNpgsqlConnection(hangfireConn), new PostgreSqlStorageOptions
            {
                SchemaName = RecurrentTasksConsts.HangfireSchema,
                QueuePollInterval = TimeSpan.FromSeconds(5)
            }));

            return services;
        }
    }
}
