using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class TicketItem:BaseEntity
    { 
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public short Status { get; set; }
        public bool IsAnswer { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
