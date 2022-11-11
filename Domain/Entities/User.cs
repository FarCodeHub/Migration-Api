using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class User:BaseEntity
    {
        public User()
        {
            Attachments = new HashSet<Attachment>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } 

        public virtual Person Person { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
