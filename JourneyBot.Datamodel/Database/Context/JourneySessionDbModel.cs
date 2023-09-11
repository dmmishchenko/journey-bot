using System.ComponentModel.DataAnnotations;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneySessionDbModel
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
