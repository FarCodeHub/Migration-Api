﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries.User;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
      
    }
}
