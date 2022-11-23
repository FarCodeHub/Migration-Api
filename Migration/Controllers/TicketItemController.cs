using Application.Commands.TicketItem.Create;
using Application.Commands.TicketItem.Update;
using Application.Queries.TicketItem;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Migration.Controllers
{
    public class TicketItemController : BaseApiController
    {
 

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTicketItemCommand command) => Ok(await mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> AnswerTicket([FromBody] UpdateTicketItemForAnswerCommand command) => Ok(await mediator.Send(command));


    }
}
