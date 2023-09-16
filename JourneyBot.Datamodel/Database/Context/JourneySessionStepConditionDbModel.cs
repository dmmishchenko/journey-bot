using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneySessionStepConditionDbModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Step))]
        public int StepId { get; set; }
        public JourneySessionStepDbModel Step { get; set; }
        public int AwaitCount { get; set; }
    }
}
