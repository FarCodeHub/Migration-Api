using Application.Interfaces;
using AutoMapper;

namespace Application.Commands.LawyerCondition.Model
{
   public class LawyerConditionModel : IMapFrom<Domain.Entities.LawyerCondition>
    {
        public int LawyerId { get; set; }
        public string Condition { get; set; }
        public bool IsAccepted { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LawyerCondition, LawyerConditionModel>();
        }
    }
}
