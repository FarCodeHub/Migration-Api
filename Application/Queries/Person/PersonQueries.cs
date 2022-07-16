using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class PersonQueries : IPersonQueries

    {
        private readonly IRepository<Person> _personRepository;
        private readonly IMapper _mapper;

        public PersonQueries(IRepository<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonQueryModel>> GetPersons()
        {
            var persons = await _personRepository.GetAll().ToListAsync();

            var personsModel = _mapper.Map<List<PersonQueryModel>>(persons);
            return personsModel;


        }

    
    }
}
