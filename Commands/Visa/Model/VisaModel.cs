using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;

namespace Application.Commands.Visa.Model
{
    public class VisaModel : IMapFrom<Domain.Entities.Visa>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Visa, VisaModel>();
        }
    }
}
