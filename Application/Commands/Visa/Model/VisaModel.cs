using Application.Interfaces;
using AutoMapper;

namespace Application.Commands
{
    public class VisaModel : IMapFrom<Domain.Entities.Visa>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Visa, VisaModel>();
        }
    }
}
