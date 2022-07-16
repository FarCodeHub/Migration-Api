using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries.Condition
{
   public class ConditionQueryModel : IMapFrom<Domain.Entities.Condition>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Condition, ConditionQueryModel>();
            //.ForMember(x => x.Conditions,
            //    opt => opt.MapFrom(x => x.LawyerCondition.Select(x => x.Condition).ToList()));
        }
    }
   
}
