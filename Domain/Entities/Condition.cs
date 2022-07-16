using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Condition : BaseEntity
    {
     
        public string Description { get; set; }
        public List<LawyerCondition> LawyerCondition { get; set; }
        public List<PersonCondition> PersonConditions { get; set; }
    }
}
