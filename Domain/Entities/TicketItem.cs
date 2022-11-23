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
        public string? Answer { get; set; }
        public DateTime? DateAnswer { get; set; }
        public DateTime? CreateDateTime { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
