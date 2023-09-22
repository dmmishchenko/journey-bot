using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyStepDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Interaction))]
        public int InteractionId { get; set; }
        public JourneyInteractionDbModel Interaction { get; set; }
        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }
        public JourneyDbModel Session { get; set; }
        [ForeignKey(nameof(Condition))]
        public int ConditionId { get; set; }
        public JourneyStepConditionDbModel Condition { get; set; }

    }
}
