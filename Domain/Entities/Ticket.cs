using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Ticket:BaseEntity
    {
        public Ticket()
        {
            TicketItems = new HashSet<TicketItem>();
        }
         
        public int UserId { get; set; }
        public int? Status { get; set; }
        public bool IsFinished { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TicketItem> TicketItems { get; set; }
    }
}
