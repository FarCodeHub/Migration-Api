using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class PersonCondition:BaseEntity
    { 
        public int PersonId { get; set; }
        public int LawyerConditionId { get; set; } 

        public virtual LawyerCondition LawyerCondition { get; set; }
        public virtual Person Person { get; set; }
    }
}
