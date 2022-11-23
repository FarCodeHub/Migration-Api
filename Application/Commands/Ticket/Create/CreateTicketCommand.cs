using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Ticket.Create
{
    public class CreateTicketCommand : IRequest<ServiceResult<bool>>, IMapFrom<CreateTicketCommand>
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } = 1;
        public int UserId { get; set; }
        public bool IsFinished { get; set; } = false;
        public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTicketCommand, Domain.Entities.User>();
        }
    }

    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ServiceResult<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Ticket> _ticketRepository;
        private readonly IRepository<Domain.Entities.TicketItem> _ticketItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Domain.Entities.Ticket> ticketRepository, IRepository<Domain.Entities.TicketItem> ticketItemRepository)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ticketItemRepository = ticketItemRepository;
        }

        public async Task<ServiceResult<bool>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            var ticket = new Domain.Entities.Ticket()
            {
                CreateDateTime = request.CreateDateTime,
                IsDeleted = false,
                IsFinished = request.IsFinished,
                Status = 1,
                Subject = request.Subject,
                UserId = request.UserId
            };
            var entity = _ticketRepository.Add(ticket);

            var ticketItem = new Domain.Entities.TicketItem()
            {
                Answer = null,
                Status = 1,
                CreateDateTime = DateTime.UtcNow,
                Descriptions = request.Description,
                Title = request.Title,
                IsDeleted = false,
                IsAnswer = false,
                Ticket = ticket,
            };
            _ticketItemRepository.Add(ticketItem);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            return new ServiceResult<bool>(true);

        }
    }

}
