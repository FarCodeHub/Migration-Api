using Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Person
{
   public interface IPersonQueries
    {
        Task<ServiceResult<PersonQueryModel>> GetPersons();
    }
}
