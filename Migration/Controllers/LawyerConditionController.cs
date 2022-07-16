using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Commands.LawyerCondition.Create;

namespace Migration.Controllers
{
    public class LawyerConditionController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLawyerConditionCommand command) =>
            Ok(await mediator.Send(command));
    }
}
