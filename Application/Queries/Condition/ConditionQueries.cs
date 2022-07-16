using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Condition
{
   public class ConditionQueries : IConditionQueries

    {
        private readonly IConditionRepository _conditionRepository;
        private readonly ILawyerConditionRepository _lawyerConditionRepository;
        private readonly IMapper _mapper;

        public ConditionQueries(IConditionRepository conditionRepository, IMapper mapper, ILawyerConditionRepository lawyerConditionRepository)
        {
            _conditionRepository = conditionRepository;
            _mapper = mapper;
            _lawyerConditionRepository = lawyerConditionRepository;
        }

        public async Task<List<ConditionQueryModel>> GetConditionsByLawyerId(int id)
        {
            var entities = await _lawyerConditionRepository.GetAll()
                .Where(x=>x.LawyerId == id)
                .Include(x=>x.Condition).Select(x=>x.Condition).ToListAsync();
            var lawyers = _mapper.Map<List<ConditionQueryModel>>(entities);
            return lawyers;


        }

     

    }
}
