using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Application.Commands.PersonLawyer.Models;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class UserQueries : IUserQueries

    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<PersonCondition> _personConditionRepository;
        private readonly IRepository<LawyerCondition> _lawyerConditionRepository;
        private readonly IRepository<PersonLawyer> _personLawyerRepository;
        private readonly IRepository<Lawyer> _lawyerRepository;
        private readonly IMapper _mapper;

        public UserQueries(IRepository<User> userRepository, IMapper mapper, IRepository<PersonCondition> personConditionRepository, IRepository<LawyerCondition> lawyerConditionRepository, IRepository<Lawyer> lawyerRepository, IRepository<PersonLawyer> personLawyerRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _personConditionRepository = personConditionRepository;
            _lawyerConditionRepository = lawyerConditionRepository;
            _lawyerRepository = lawyerRepository;
            _personLawyerRepository = personLawyerRepository;
        }

        public async Task<ServiceResult<UserQueryModel>> GetUser(string userName, string password)
        {
            var userModel = new UserQueryModel();

            var user = await _userRepository.GetAll().Include(x => x.Person)
                .Where(x => x.UserName.Equals(userName) && x.Password.Equals(password)).FirstOrDefaultAsync();

            if (user is null) return new ServiceResult<UserQueryModel>(false);

            var DoesUserIsValid = user != null ;
            var personLawyers = new List<PersonLawyerModel>();

            if (DoesUserIsValid) {

                  personLawyers = await (from pl in _personLawyerRepository.GetAll()
                                           join l in _lawyerRepository.GetAll() on pl.LawyerId equals l.Id
                                           where pl.PersonId == user.PersonId
                                           select new PersonLawyerModel
                                           {
                                               FullName = l.FullName,
                                               PersonId = pl.PersonId,
                                               LawyerId = pl.LawyerId

                                           }).ToListAsync();

                var ids = personLawyers.Select(x => x.LawyerId).ToList();

                var lawyerConditions = await (from pc in _personConditionRepository.GetAll()
                                              join lc in _lawyerConditionRepository.GetAll() on pc.LawyerConditionId equals lc.Id
                                              where ids.Contains(lc.LawyerId)
                                              select new LawyerConditionModel
                                              {
                                                  Id = lc.Id,
                                                  LawyerId = lc.LawyerId,
                                                  Title = lc.Title
                                              }).ToListAsync();

                foreach (var item in personLawyers)
                    item.LawyerConditionModels = lawyerConditions.Where(x => x.LawyerId == item.LawyerId).ToList();

               
            }

                userModel = _mapper.Map<UserQueryModel>(user);
            if (user.Person == null)
                return new ServiceResult<UserQueryModel>(false);

            userModel.Status = (int)user.Person.Status;
                if (personLawyers.Count >0)
                userModel.PersonLawyers = personLawyers;

            return new ServiceResult<UserQueryModel>(userModel, true);

        }
    }
}
