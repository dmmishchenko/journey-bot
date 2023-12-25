using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneySessionOptionDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Interaction))]
        public int InteractionId { get; set; }
        public JourneySessionInteractionDbModel Interaction { get; set; }
        public bool IsCompleted { get; set; }
        [InverseProperty(nameof(JourneyUserInteractionDbModel.Option))]
        public ICollection<JourneyUserInteractionDbModel> UsersInteractions { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? CompleteDate { get; set; }
        public DateTimeOffset? VoteDate { get; set; }
    }
}
