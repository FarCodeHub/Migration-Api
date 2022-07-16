using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Queries.Lawyer;

namespace Migration.Controllers
{
    public class LawyerController : BaseApiController
    {

        private readonly ILawyerQueries _lawyerQueries;

        public LawyerController(ILawyerQueries lawyerQueries)
        {
            _lawyerQueries = lawyerQueries;
        }

        [HttpGet]
        public async Task<IActionResult> GetLawyers()
        {
            var result = await _lawyerQueries.GetLawyers();
            return Ok(result);
        }
    }
}
