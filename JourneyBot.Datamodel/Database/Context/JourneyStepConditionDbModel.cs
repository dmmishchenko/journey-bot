using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyStepConditionDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Step))]
        public int StepId { get; set; }
        public JourneyStepDbModel Step { get; set; }
        public int? SecondsCount { get; set; }
    }
}
