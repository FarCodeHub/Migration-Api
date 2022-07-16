namespace Domain.Entities
{
   public class Attachment:BaseEntity
    {
        public string FileName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
     }
}
