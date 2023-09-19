using JourneyBot.Datamodel.Database.Users;
using Microsoft.EntityFrameworkCore;

namespace Journey.Users.Database.Context
{
    public class JourneyUsersContext : DbContext
    {
        public JourneyUsersContext(DbContextOptions<JourneyUsersContext> options) : base(options)
        {

        }

        public DbSet<UserDbModel> Users { get; set; }
    }
}
