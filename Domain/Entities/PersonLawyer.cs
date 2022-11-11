using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class PersonLawyer :BaseEntity
    { 
        public int PersonId { get; set; }
        public int LawyerId { get; set; } 

        public virtual Lawyer Lawyer { get; set; }
        public virtual Person Person { get; set; }
    }
}
