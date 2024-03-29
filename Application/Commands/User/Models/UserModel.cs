﻿using Application.Interfaces;
using AutoMapper;

namespace Application.Commands
{
   public class UserModel:IMapFrom<Domain.Entities.User>
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserModel>();

        }
    }
}
