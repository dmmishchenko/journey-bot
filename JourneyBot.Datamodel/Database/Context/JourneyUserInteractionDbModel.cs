using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyUserInteractionDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Action))]
        public int? ActionId { get; set; }
        public JourneyUsersActionDbModel Action { get; set; }
        [ForeignKey(nameof(Option))]
        public int? OptionId { get; set; }
        public JourneyUsersOptionDbModel Option { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
