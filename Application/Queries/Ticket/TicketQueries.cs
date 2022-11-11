using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Ticket
{
   public class TicketQueries : ITicketQueries

    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Ticket> _ticketRepository;

        public TicketQueries(IRepository<Domain.Entities.Ticket> ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketModel>> GetTicketByUserId(int userId)
        {
            var results = await _ticketRepository.GetAll().Where(x => x.UserId == userId)
                .Include(x=>x.TicketItems)
                .ToListAsync();
            var tickets =   _mapper.Map<List<TicketModel>>(results);
            return tickets;
        }
 
    }
}
