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
        [InverseProperty(nameof(JourneyUsersOptionDbModel.Interaction))]
        public ICollection<JourneyUsersOptionDbModel> Options { get; set; }
        [InverseProperty(nameof(JourneyUsersActionDbModel.Interaction))]
        public ICollection<JourneyUsersActionDbModel> Actions { get; set; }
    }
}
