using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence;
using Persistence.Repositories;

namespace Infrastracture.Repositories
{
   public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(MigrationContext context) : base(context)
        {
        }


    }
}
