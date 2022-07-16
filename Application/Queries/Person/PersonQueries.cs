using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
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

        public async Task<List<PersonQueryModel>> GetPersons()
        {
            var persons = await _personRepository.GetAll().ToListAsync();

            var personsModel = _mapper.Map<List<PersonQueryModel>>(persons);
            return personsModel;


        }

    
    }
}
