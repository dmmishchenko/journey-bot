using JourneyBot.Datamodel.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace JourneyBot.Database.Context
{
    public class JourneyBotContext : DbContext
    {
        public JourneyBotContext(DbContextOptions<JourneyBotContext> options) : base(options)
        {

        }

        #region Journey info
        public DbSet<JourneyDbModel> Journeys { get; set; }
        public DbSet<JourneyStepDbModel> Steps { get; set; }
        public DbSet<JourneyStepConditionDbModel> StepConditions { get; set; }
        public DbSet<JourneyInteractionDbModel> Interactions { get; set; }
        public DbSet<JourneyActionDbModel> Actions { get; set; }
        public DbSet<JourneyOptionDbModel> Options { get; set; }
        #endregion

        #region Session info
        public DbSet<JourneySessionDbModel> Sessions { get; set; }
        public DbSet<JourneySessionStepDbModel> SessionSteps { get; set; }
        public DbSet<JourneySessionStepConditionDbModel> SessionStepConditions { get; set; }
        public DbSet<JourneySessionInteractionDbModel> SessionStepInteractions { get; set; }
        public DbSet<JourneySessionActionDbModel> SessionActions { get; set; }
        public DbSet<JourneySessionOptionDbModel> SessionOptions { get; set; }
        #endregion

        #region User actions info
        public JourneyUserMessageDbModel UserMessages { get; set; }
        public DbSet<JourneySessionUsersMessageDbModel> UsersSessionMessages { get; set; }
        public DbSet<JourneyUserInteractionDbModel> UserInteractions { get; set; }
        #endregion

        public DbSet<JourneyBotMessageDbModel> BotMessages { get; set; }
    }
}
