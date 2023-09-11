using System.ComponentModel.DataAnnotations;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyInteractionDbModel
    {
        [Key]
        public int Id { get; set; }
    }
}
