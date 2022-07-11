using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.Wrapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.User
{
   public class UserQueries: IUserQueries

    {
       private readonly IUserRepository _userRepository;
       private readonly IMapper _mapper;

        public UserQueries(IUserRepository userRepository, IMapper mapper)
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
