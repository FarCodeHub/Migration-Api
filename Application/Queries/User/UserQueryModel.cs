using System.Collections.Generic;
using Application.Commands.PersonLawyer.Models;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries
{
   public class UserQueryModel:IMapFrom<Domain.Entities.User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public int Status { get; set; }
        public bool? IsAdmin { get; set; }
        public List<PersonLawyerModel> PersonLawyers { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserQueryModel>();
        }
    }
}
