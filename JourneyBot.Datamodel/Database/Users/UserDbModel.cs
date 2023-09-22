using System.ComponentModel.DataAnnotations;

namespace JourneyBot.Datamodel.Database.Users
{
    public class UserDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? TelegramId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
