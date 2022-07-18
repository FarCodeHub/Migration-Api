using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Commands.PersonLawyer.Models
{
    public class PersonLawyerModel:IMapFrom<Domain.Entities.PersonLawyer>
    {
        public int PersonId { get; set; }
        public int LawyerId { get; set; }
        public string FullName { get; set; }
        public List<LawyerConditionModel> LawyerConditionModels { get; set; }
        public List<PersonCondition> PersonConditions { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.PersonLawyer, PersonLawyerModel>();
        }

    }
}
