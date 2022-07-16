using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.Lawyer
{
   public interface ILawyerQueries
    {
        Task<List<LawyerQueryModel>> GetLawyers();
    }
}
