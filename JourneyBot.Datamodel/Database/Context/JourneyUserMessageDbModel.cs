using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyUserMessageDbModel
    {
        [Key]
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? Option { get; set; }
        [ForeignKey(nameof(UsersMessage))]
        public int? UsersMessageId { get; set; }
        public JourneySessionUsersMessageDbModel UsersMessage { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
