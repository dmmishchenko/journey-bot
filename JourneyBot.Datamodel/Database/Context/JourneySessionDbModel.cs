using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneySessionDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Journey))]
        public int JourneyId { get; set; }
        public JourneyDbModel Journey { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? PauseDate { get; set; }
        public DateTimeOffset? CompleteDate { get; set; }
        public bool IsPaused { get; set; }
    }
}
