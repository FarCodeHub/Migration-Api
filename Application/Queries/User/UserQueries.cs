using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
   public class UserQueries: IUserQueries

    {
       private readonly IRepository<User> _userRepository;
       private readonly IMapper _mapper;

        public UserQueries(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserQueryModel>> GetUser(string userName, string password)
        {
            var user = await _userRepository.GetAll()
                .Where(x => x.UserName.Equals(userName) && x.Password.Equals(password)).FirstOrDefaultAsync();
            try
            {
                if (user is null)
                    return new ServiceResult<UserQueryModel>( false);

                var userModel = _mapper.Map<UserQueryModel>(user);
                return new ServiceResult<UserQueryModel>(userModel,true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



        }
   }
}
