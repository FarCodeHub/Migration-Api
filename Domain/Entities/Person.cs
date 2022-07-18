using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string IsMarried { get; set; }
        public string PhoneNumber { get; set; }
        public string VisaType { get; set; }
        public string VisaStatus { get; set; }
        public int Status { get; set; } = 0;
        public DateTime VisaExpirationDate { get; set; }
        public User User { get; set; }
        public Visa Visa { get; set; }
        public List<PersonLawyer> PersonLawyers { get; set; }
        public List<PersonCondition> PersonConditions { get; set; }



    }
}
