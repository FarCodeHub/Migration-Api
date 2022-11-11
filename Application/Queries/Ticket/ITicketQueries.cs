using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.Ticket
{
   public interface ITicketQueries 
    {
        Task<List<TicketModel>> GetTicketByUserId(int userId);
    }
}
