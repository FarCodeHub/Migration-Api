using System.Threading.Tasks;
using Application.Wrapper;

namespace Application.Queries.User
{
   public interface IUserQueries
    {
        Task<ServiceResult<UserQueryModel>> GetUser(string userName, string password);
    }
}
