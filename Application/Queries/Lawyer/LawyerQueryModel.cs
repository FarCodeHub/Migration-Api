using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries
{
   public class LawyerQueryModel : IMapFrom<Domain.Entities.Lawyer>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public List<LawyerConditionModel> Conditions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Lawyer, LawyerQueryModel>()
            .ForMember(x => x.Conditions,
                opt => opt.MapFrom(x => x.LawyerCondition));
        }
    }

    public class LawyerConditionModel : IMapFrom<Domain.Entities.LawyerCondition>
    {
        public int LawyerId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LawyerCondition, LawyerConditionModel>();
        }
    }


}
