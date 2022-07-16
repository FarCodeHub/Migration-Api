using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class PersonLawyer:BaseEntity
    {
        public int PersonId { get; set; }
        public int LawyerId { get; set; }
        public Person Person { get; set; }
        public Lawyer Lawyer { get; set; }
    }
}
