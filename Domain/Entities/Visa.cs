using System;

namespace Domain.Entities
{
    public class Visa : BaseEntity
    {
       
        public int PersonId { get; set; }
        public string VisaType { get; set; }
        public string VisaStatus { get; set; }
        public DateTime VisaExpairationDate { get; set; }
        public Person Person { get; set; }

    }
}
