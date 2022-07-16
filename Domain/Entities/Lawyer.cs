using System.Collections.Generic;

namespace Domain.Entities
{
       
       
    public class Lawyer :BaseEntity
    {
     
        public string FullName { get; set; }
        public string Code { get; set; }
     
        public List<LawyerCondition> LawyerCondition { get; set; }
        public List<PersonLawyer> PersonLawyers { get; set; }

    }
}
