using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Wrapper;

namespace Application.Queries.User
{
   public interface IUserQueries
    {
        Task<ServiceResult<UserQueryModel>> GetUser(string userName, string password);
    }
}
