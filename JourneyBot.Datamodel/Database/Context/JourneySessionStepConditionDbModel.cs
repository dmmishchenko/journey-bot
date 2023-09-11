using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneySessionStepConditionDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }
        public JourneySessionDbModel Session { get; set; }
        [ForeignKey(nameof(Step))]
        public int StepId { get; set; }
        public JourneySessionStepDbModel Step { get; set; }
        public int SecondsCount { get; set; }
    }
}
