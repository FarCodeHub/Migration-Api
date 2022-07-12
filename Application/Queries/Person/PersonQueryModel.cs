using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Queries.User;
using AutoMapper;

namespace Application.Queries.Person
{
   public class PersonQueryModel : IMapFrom<Domain.Entities.Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string IsMarried { get; set; }
        public string PhoneNumber { get; set; }
        public string VisaType { get; set; }
        public string VisaStatus { get; set; }
      //  public DateTime VisaExpirationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Person, PersonQueryModel>();
        }
}
}
