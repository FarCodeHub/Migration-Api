using Application.Interfaces;
using AutoMapper;

namespace Application.Queries
{
   public class PersonQueryModel : IMapFrom<Domain.Entities.Person>
    {
        public int Id { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string IsMarried { get; set; }
        public string PhoneNumber { get; set; }
        public string VisaType { get; set; }
        public string VisaStatus { get; set; }
        public bool? IsDeleted { get; set; }
        //  public DateTime VisaExpirationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Person, PersonQueryModel>();
        }
}
}
