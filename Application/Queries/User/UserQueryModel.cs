using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Person;
using Application.Interfaces;
using AutoMapper;

namespace Application.Queries.User
{
   public class UserQueryModel:IMapFrom<Domain.Entities.User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserQueryModel>();
        }
    }
}
