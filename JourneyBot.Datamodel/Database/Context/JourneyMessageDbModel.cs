using JourneyBot.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyMessageDbModel
    {
        [Key]
        public int Id { get; set; }
        public MessageType Type { get; set; }
    }
}
