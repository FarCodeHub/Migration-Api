using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Visa:BaseEntity
    { 
        public int PersonId { get; set; }
        public string VisaType { get; set; }
        public string VisaStatus { get; set; }
        public DateTime VisaExpairationDate { get; set; } 

        public virtual Person Person { get; set; }
    }
}
