using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyUserInteractionDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(UserMessage))]
        public int UserMessageId { get; set; }
        public JourneyUserMessageDbModel UserMessage { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
