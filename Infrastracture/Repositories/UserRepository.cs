using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Repositories;
using Persistence;

namespace Infrastracture.Repositories
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(MigrationContext context) : base(context)
        {
        }


    }
}
