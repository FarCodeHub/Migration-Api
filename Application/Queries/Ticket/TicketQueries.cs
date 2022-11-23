using Application.Interfaces;
using Application.Queries.TicketItem;
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
        private readonly IRepository<Domain.Entities.TicketItem> _ticketItemRepository;
        private readonly IRepository<Domain.Entities.Ticket> _ticketRepository;
        private readonly IRepository<Domain.Entities.Person> _personRepository;
        private readonly IRepository<Domain.Entities.User> _userRepository;

        public TicketQueries(IRepository<Domain.Entities.Ticket> ticketRepository, IMapper mapper, IRepository<Domain.Entities.User> userRepository, IRepository<Domain.Entities.Person> personRepository, IRepository<Domain.Entities.TicketItem> ticketItemRepository)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _personRepository = personRepository;
            _ticketItemRepository = ticketItemRepository;
        }

        public async Task<List<TicketModel>> GetTicketByUserId(int userId)
        {
            var results = await _ticketRepository.GetAll().Where(x => x.UserId == userId)
                .Include(x=>x.TicketItems)
                .ToListAsync();
            var tickets =   _mapper.Map<List<TicketModel>>(results);
            return tickets;
        }

        public async Task<List<TicketModel>> GetTicketsWithoutAnswer()
        {
            var tickets = await (from t in _ticketRepository.GetAll()
                                 join u in _userRepository.GetAll() on t.UserId equals u.Id
                                 join p in _personRepository.GetAll() on u.PersonId equals p.Id
                                 where t.IsFinished != true
                                 select new TicketModel
                                 {
                                     FullName = p.FirstName +" "+p.LastName,
                                     CreateDateTime = t.CreateDateTime,
                                     Id = t.Id,
                                     Status = t.Status,
                                     UserId = u.Id,
                                     Subject = t.Subject,
                                     UserName = u.UserName
                                 }).ToListAsync();

            var ticketsId = tickets.Select(x => x.Id).ToList();

            var ticketItems = await (from ti in _ticketItemRepository.GetAll()
                                     join t in _ticketRepository.GetAll() on ti.TicketId equals t.Id
                                     join u in _userRepository.GetAll() on t.UserId equals u.Id
                                     where (ticketsId.Contains(ti.TicketId))
                                     select new TicketItemModel
                                     {
                                         TicketId = ti.TicketId,
                                         Title = ti.Title,
                                         Descriptions = ti.Descriptions,
                                         Answer = ti.Answer,
                                         DateAnswer = ti.DateAnswer,
                                         IsAnswer = ti.IsAnswer,
                                         Status = ti.Status,
                                         CreateDateTime = ti.CreateDateTime,
                                         Id = ti.Id,
                                         UserName = u.UserName
                                     }).ToListAsync();

            foreach (var item in tickets)
                item.TicketItems = ticketItems.Where(x => x.TicketId == item.Id).ToList();

            return _mapper.Map<List<TicketModel>>(tickets);
        }
    }
}
