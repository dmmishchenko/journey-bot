using JourneyBot.Datamodel.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace JourneyBot.Database.Context
{
    public class JourneyBotContext : DbContext
    {
        public JourneyBotContext(DbContextOptions<JourneyBotContext> options) : base(options)
        {

        }

        public DbSet<JourneyDbModel> Journeys { get; set; }
        public DbSet<JourneyStepDbModel> Steps { get; set; }
        public DbSet<JourneyStepConditionDbModel> StepConditions { get; set; }
        public DbSet<JourneyInteractionDbModel> Interactions { get; set; }
        public DbSet<JourneyActionDbModel> Actions { get; set; }
        public DbSet<JourneyOptionDbModel> Options { get; set; }
        public DbSet<JourneyUsersMessageDbModel> Messages { get; set; }
        public DbSet<JourneySessionDbModel> Sessions { get; set; }
        public DbSet<JourneySessionStepDbModel> SessionSteps { get; set; }
        public DbSet<JourneySessionStepConditionDbModel> SessionStepConditions { get; set; }
        public DbSet<JourneySessionInteractionDbModel> SessionStepInteractions { get; set; }
        public DbSet<JourneyUsersActionDbModel> UsersActions { get; set; }
        public DbSet<JourneyUsersOptionDbModel> UsersOptions { get; set; }
        public DbSet<JourneyUserInteractionDbModel> UserActions { get; set; }
        public DbSet<JourneyBotMessageDbModel> BotMessages { get; set; }
    }
}
