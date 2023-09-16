using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneySessionStepDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }
        public JourneySessionDbModel Session { get; set; }
        [ForeignKey(nameof(Condition))]
        public int ConditionId { get; set; }
        public JourneySessionStepConditionDbModel Condition { get; set; }
        [ForeignKey(nameof(Interaction))]
        public int InteractionId { get; set; }
        public JourneySessionInteractionDbModel Interaction { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? CompleteDate { get; set; }
    }
}
