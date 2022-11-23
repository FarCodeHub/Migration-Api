using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.TicketItem.Update
{
   public class UpdateTicketItemForAnswerCommand : IRequest<ServiceResult<bool>>, IMapFrom<UpdateTicketItemForAnswerCommand>
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Status { get; set; } = 1;
        public int UserId { get; set; }
        public bool IsFinished { get; set; } = false;
        public int TicketId { get; set; }
        public bool IsAnswerd { get; set; }
        public string Answer { get; set; }
        public DateTime DateAnswer { get; set; } = DateTime.UtcNow;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTicketItemForAnswerCommand, Domain.Entities.TicketItem>();

        }

    }
    public class UpdateTicketItemForAnswerCommandHandler : IRequestHandler<UpdateTicketItemForAnswerCommand, ServiceResult<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Ticket> _ticketRepository;
        private readonly IRepository<Domain.Entities.TicketItem> _ticketItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketItemForAnswerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Domain.Entities.Ticket> ticketRepository, IRepository<Domain.Entities.TicketItem> ticketItemRepository)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ticketItemRepository = ticketItemRepository;
        }

        public async Task<ServiceResult<bool>> Handle(UpdateTicketItemForAnswerCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

            var ticketEntity =await _ticketRepository.GetAll().Where(x => x.Id == request.TicketId).Include(x=>x.TicketItems).FirstAsync();

            var ticketItemEntity = ticketEntity.TicketItems.Where(x => x.Id == request.Id).First();

             FinishTicketItem(ticketItemEntity, request);

            if (request.Status == 3)
                FinishTicket(ticketEntity);
            else
            { 

            var isFininshedTicket = ticketEntity.TicketItems.Where(x => x.Status != 3).Any();

            if (!isFininshedTicket)
                FinishTicket(ticketEntity);
          
            ticketEntity.Status = request.Status;

            }

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            return new ServiceResult<bool>(true);
        }


        private Domain.Entities.TicketItem FinishTicketItem(Domain.Entities.TicketItem ticketItem, UpdateTicketItemForAnswerCommand request)
        {
            ticketItem.Answer = request.Answer;
            ticketItem.IsAnswer = true;
            ticketItem.Status = request.Status;
            ticketItem.DateAnswer = DateTime.UtcNow;
            return ticketItem;
        }

        private Domain.Entities.Ticket FinishTicket(Domain.Entities.Ticket ticket)
        {
            ticket.Status =3;
            ticket.IsFinished = true;
            return ticket;

        }

    }


}
