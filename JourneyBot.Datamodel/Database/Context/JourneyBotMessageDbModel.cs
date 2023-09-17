using System.ComponentModel.DataAnnotations;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyBotMessageDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCommand { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
