using System;
using System.Collections.Generic;
 

namespace Domain.Entities
{
    public partial class Lawyer:BaseEntity
    {
        public Lawyer()
        {
            LawyerConditions = new HashSet<LawyerCondition>();
            PersonLawyers = new HashSet<PersonLawyer>();
        }

        
        public string FullName { get; set; }
        public string Code { get; set; }
        
        public virtual ICollection<LawyerCondition> LawyerConditions { get; set; }
        public virtual ICollection<PersonLawyer> PersonLawyers { get; set; }
    }
}
