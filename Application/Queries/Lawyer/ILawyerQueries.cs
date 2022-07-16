using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries
{
   public interface ILawyerQueries
    {
        Task<List<LawyerQueryModel>> GetLawyers();
    }
}
