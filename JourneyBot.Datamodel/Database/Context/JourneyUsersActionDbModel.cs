using System.ComponentModel.DataAnnotations;

namespace JourneyBot.Datamodel.Database.Context
{
    public class JourneyUsersActionDbModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public bool IsOptional { get; set; }
        public int StepId { get; set; }
        public int MyProperty { get; set; }
    }
}
