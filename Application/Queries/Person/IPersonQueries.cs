﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries
{
   public interface IPersonQueries
    {
        Task<List<PersonQueryModel>> GetPersons();
    }
}
