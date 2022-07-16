using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Lawyer
{
   public class LawyerQueries : ILawyerQueries

    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly ILawyerConditionRepository _lawyerConditionRepository;
        private readonly IMapper _mapper;

        public LawyerQueries(ILawyerRepository lawyerRepository, IMapper mapper, ILawyerConditionRepository lawyerConditionRepository)
        {
            _lawyerRepository = lawyerRepository;
            _mapper = mapper;
            _lawyerConditionRepository = lawyerConditionRepository;
        }

        public async Task<List<LawyerQueryModel>> GetLawyers()
        {
            var entities = await _lawyerRepository.GetAll().ToListAsync();
                //.Include(x=>x.LawyerCondition)
                //.ThenInclude(x=>x.Condition).ProjectTo<LawyerQueryModel>(_mapper.ConfigurationProvider).ToListAsync();
            var lawyers = _mapper.Map<List<LawyerQueryModel>>(entities);
            return lawyers;


        }


      
    }
}
