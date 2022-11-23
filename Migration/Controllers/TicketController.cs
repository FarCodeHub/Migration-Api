using Application.Commands.Ticket.Create;
using Application.Queries.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migration.Controllers
{
    public class TicketController : BaseApiController
    {
        private readonly ITicketQueries _ticketQueries;

        public TicketController(ITicketQueries ticketQueries)
        {
            _ticketQueries = ticketQueries;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTicketCommand command) =>
    Ok(await mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetTicketByUserId(int id)
        {
            var result = await _ticketQueries.GetTicketByUserId(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketsWithoutAnswer()
        {
            var result = await _ticketQueries.GetTicketsWithoutAnswer();
            return Ok(result);
        }
 

    }
}
