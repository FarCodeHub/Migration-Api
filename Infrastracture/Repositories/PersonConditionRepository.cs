using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence;
using Persistence.Repositories;

namespace Infrastracture.Repositories
{
   public class PersonConditionRepository:Repository<PersonCondition>,IPersonConditionRepository
    {
        public PersonConditionRepository(MigrationContext context) : base(context)
        {
        }
    }
}
