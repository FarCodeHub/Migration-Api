using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TicketItem
{
   public class TicketItemQueries : ITicketItemQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.TicketItem> _ticketItemRepository;
        private readonly IRepository<Domain.Entities.Ticket> _ticketRepository;
        private readonly IRepository<Domain.Entities.Person> _personRepository;
        private readonly IRepository<Domain.Entities.User> _userRepository;
        public TicketItemQueries(IMapper mapper, IRepository<Domain.Entities.TicketItem> ticketItemRepository,
            IRepository<Domain.Entities.Ticket> ticketRepository,
            IRepository<Domain.Entities.Person> personRepository,
            IRepository<Domain.Entities.User> userRepository)
        {
            _mapper = mapper;
            _ticketItemRepository = ticketItemRepository;
            _ticketRepository = ticketRepository;
            _personRepository = personRepository;
            _userRepository = userRepository;
        }

        public async Task<List<TicketItemModel>> GetAllTicketWithoutAnswer()
        {
            var result =await (from ti in _ticketItemRepository.GetAll()
                 join t in _ticketRepository.GetAll() on ti.TicketId equals t.Id
                 join u in _userRepository.GetAll() on t.UserId equals u.Id
                 join p in _personRepository.GetAll() on u.PersonId equals p.Id
                  where t.IsFinished != true && ti.IsAnswer !=true
                               select new TicketItemModel
                               {
                                   FullName = p.FirstName +" "+ p.LastName,
                                   CreateDateTime = ti.CreateDateTime,
                                   TicketId = ti.TicketId,
                                   Id = ti.Id,
                                   Title = ti.Title,
                                   Descriptions = ti.Descriptions,
                                   Status = ti.Status,
                                   UserId = u.Id
                               }).ToListAsync();

            var ticketItems = _mapper.Map<List<TicketItemModel>>(result);
            return ticketItems;
        }
    }
}
