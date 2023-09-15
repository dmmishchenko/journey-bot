﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyUsersActionDbModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Interaction))]
        public int InteractionId { get; set; }
        public JourneySessionInteractionDbModel Interaction { get; set; }
        public bool IsCompleted { get; set; }
        [InverseProperty(nameof(JourneyUserInteractionDbModel.Action))]
        public ICollection<JourneyUserInteractionDbModel> UsersInteractions { get; set; }
    }
}
