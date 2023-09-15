using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyInteractionDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        [ForeignKey(nameof(Step))]
        public int StepId { get; set; }
        public JourneyStepDbModel Step { get; set; }
        [InverseProperty(nameof(JourneyOptionDbModel.Interaction))]
        public ICollection<JourneyOptionDbModel> Options { get; set; }
        [InverseProperty(nameof(JourneyActionDbModel.Interaction))]
        public ICollection<JourneyActionDbModel> Actions { get; set; }
    }
}
