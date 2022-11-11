using System;
using System.Collections.Generic;
 

namespace Domain.Entities
{
    public partial class LawyerCondition:BaseEntity
    {
        public LawyerCondition()
        {
            PersonConditions = new HashSet<PersonCondition>();
        }

        //public int Id { get; set; }
        public string Title { get; set; }
        public int LawyerId { get; set; }
        //public bool? IsDeleted { get; set; }

        public virtual Lawyer Lawyer { get; set; }
        public virtual ICollection<PersonCondition> PersonConditions { get; set; }
    }
}
