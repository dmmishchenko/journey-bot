using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyDbModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsStoped { get; set; }
        [InverseProperty(nameof(JourneyStepDbModel.Session))]
        public ICollection<JourneyStepDbModel> Steps { get; set; }
    }
}
