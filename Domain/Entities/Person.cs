using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Person : BaseEntity
    {
        public Person()
        {
            PersonConditions = new HashSet<PersonCondition>();
            PersonLawyers = new HashSet<PersonLawyer>();
            Users = new HashSet<User>();
            Visas = new HashSet<Visa>();
        }

     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string IsMarried { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime VisaExpirationDate { get; set; }
        public string VisaStatus { get; set; }
        public string VisaType { get; set; }
      
        public int? Status { get; set; }

        public virtual ICollection<PersonCondition> PersonConditions { get; set; }
        public virtual ICollection<PersonLawyer> PersonLawyers { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Visa> Visas { get; set; }
    }
}
