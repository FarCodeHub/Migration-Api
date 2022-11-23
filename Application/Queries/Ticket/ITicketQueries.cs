using Application.Interfaces;
using Application.Queries.TicketItem;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.Ticket
{
   public interface ITicketQueries 
    {
        Task<List<TicketModel>> GetTicketByUserId(int userId);

        Task<List<TicketModel>> GetTicketsWithoutAnswer();
    }
}
