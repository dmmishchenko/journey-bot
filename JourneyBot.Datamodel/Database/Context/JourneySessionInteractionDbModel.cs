using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneySessionInteractionDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Step))]
        public int StepId { get; set; }
        public JourneySessionStepDbModel Step { get; set; }
        public int InteractionId { get; set; }
        [InverseProperty(nameof(JourneySessionOptionDbModel.Interaction))]
        public ICollection<JourneySessionOptionDbModel> Options { get; set; }
        [InverseProperty(nameof(JourneySessionActionDbModel.Interaction))]
        public ICollection<JourneySessionActionDbModel> Actions { get; set; }
    }
}
