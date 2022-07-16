using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.Condition
{
   public interface IConditionQueries
    {
        Task<List<ConditionQueryModel>> GetConditionsByLawyerId(int id);
    }
}
