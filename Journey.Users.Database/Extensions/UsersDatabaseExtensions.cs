using Journey.Users.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Journey.Users.Database.Extensions
{
    public static class UsersDatabaseExtensions
    {
        public static IServiceCollection AddUsersDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<JourneyUsersContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
