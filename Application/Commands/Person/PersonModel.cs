using Application.Interfaces;
using AutoMapper;

namespace Application.Commands
{
  public class PersonModel:IMapFrom<Domain.Entities.Person>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Person, PersonModel>();
        }
    }
}
