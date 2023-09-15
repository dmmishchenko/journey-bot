using System.ComponentModel.DataAnnotations;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyDbModel
    {
        [Key]
        public int Id { get; set; }
    }
}
