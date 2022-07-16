using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
       
        public int? PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Person Person { get; set; }
        public List<Attachment> Attachments { get; set; }


    }
}
