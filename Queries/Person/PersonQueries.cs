using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Queries.User;
using Application.Wrapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Person
{
    public class PersonQueries : IPersonQueries

    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonQueries(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PersonQueryModel>> GetPersons()
        {
            var persons = await _personRepository.GetAll().ToListAsync();

            var map = _mapper.Map<PersonQueryModel>(persons);
            return new ServiceResult<PersonQueryModel>(map, true);


        }

    
    }
}
