using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Queries;
using Application.Commands;

namespace Migration.Controllers
{
    public class PersonController : BaseApiController
    {
        private readonly IPersonQueries _personQueries;

        public PersonController(IPersonQueries personQueries)
        {
            _personQueries = personQueries;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePersonCommand command) =>
            Ok(await mediator.Send(command));
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var result =await _personQueries.GetPersons();
            return Ok(result);
    }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id) => Ok( await mediator.Send(new DeletePersonCommand { Id = id }));

    }
}
