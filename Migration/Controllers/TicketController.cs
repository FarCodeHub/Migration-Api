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


        [HttpGet]
        public async Task<IActionResult> GetTicketByUserId(int userId)
        {
            var result = await _ticketQueries.GetTicketByUserId(userId);
            return Ok(result);
        }
    }
}
