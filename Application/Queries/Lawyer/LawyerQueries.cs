using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
   public class LawyerQueries : ILawyerQueries

    {
        private readonly IRepository<Lawyer> _lawyerRepository;
        private readonly IRepository<LawyerCondition> _lawyerConditionRepository;
        private readonly IMapper _mapper;

        public LawyerQueries(IRepository<Lawyer> lawyerRepository, IMapper mapper, IRepository<LawyerCondition> lawyerConditionRepository)
        {
            _lawyerRepository = lawyerRepository;
            _mapper = mapper;
            _lawyerConditionRepository = lawyerConditionRepository;
        }

        public async Task<List<LawyerQueryModel>> GetLawyers()
        {
            var entities = await _lawyerRepository.GetAll()
                .Include(x => x.LawyerConditions).ToListAsync();
            var lawyers = _mapper.Map<List<LawyerQueryModel>>(entities);
            return lawyers;


        }


      
    }
}
