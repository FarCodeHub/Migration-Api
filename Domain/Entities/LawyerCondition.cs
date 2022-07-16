using System.Collections.Generic;

namespace Domain.Entities
{
   public class LawyerCondition : BaseEntity
    {
  
        public int LawyerId { get; set; }
        public string Title { get; set; }
        
        public virtual Lawyer Lawyer { get; set; }

        public ICollection<PersonCondition> PersonConditions { get; set; }

    }
}
