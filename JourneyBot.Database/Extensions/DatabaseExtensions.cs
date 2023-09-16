using JourneyBot.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyBot.Database.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddJourneyBotDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<JourneyBotContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
