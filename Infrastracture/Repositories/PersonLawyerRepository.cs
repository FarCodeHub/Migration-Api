using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence;
using Persistence.Repositories;

namespace Infrastracture.Repositories
{
    public class PersonLawyerRepository:Repository<PersonLawyer>,IPersonLawyerRepository
    {
        public PersonLawyerRepository(MigrationContext context) : base(context)
        {
        }
    }
}
