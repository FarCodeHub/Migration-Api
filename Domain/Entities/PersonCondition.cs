using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class PersonCondition:BaseEntity
    {
        public int PersonId { get; set; }
        public int ConditionId { get; set; }
        public Person Person { get; set; }
        
        public virtual LawyerCondition LawyerCondition { get; set; }


    }
}
