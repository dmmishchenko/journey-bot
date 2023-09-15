using JourneyBot.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyUsersMessageDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }
        public JourneySessionDbModel Session { get; set; }
        public MessageType Type { get; set; }
        [ForeignKey(nameof(Action))]
        public int? ActionId { get; set; }
        public JourneyUsersActionDbModel Action { get; set; }
        [ForeignKey(nameof(Option))]
        public int? OptionId { get; set; }
        public JourneyUsersOptionDbModel Option { get; set; }
    }
}
