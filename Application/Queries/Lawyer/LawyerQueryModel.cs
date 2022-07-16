using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries.Lawyer
{
   public class LawyerQueryModel : IMapFrom<Domain.Entities.Lawyer>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public List<Domain.Entities.Condition> Conditions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Lawyer, LawyerQueryModel>();
            //.ForMember(x => x.Conditions,
            //    opt => opt.MapFrom(x => x.LawyerCondition.Select(x => x.Condition).ToList()));
        }
    }
   
}
