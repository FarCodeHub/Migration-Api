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

namespace Application.Commands.TicketItem.Create
{
    public class CreateTicketItemCommand : IRequest<ServiceResult<bool>>, IMapFrom<CreateTicketItemCommand>
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } = 1;
        public int UserId { get; set; }
        public bool IsFinished { get; set; } = false;
        public int TicketId { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTicketItemCommand, Domain.Entities.TicketItem>();
        }
    }

    public class CreateTicketItemCommandHandler : IRequestHandler<CreateTicketItemCommand, ServiceResult<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Ticket> _ticketRepository;
        private readonly IRepository<Domain.Entities.TicketItem> _ticketItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketItemCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Domain.Entities.Ticket> ticketRepository, IRepository<Domain.Entities.TicketItem> ticketItemRepository)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ticketItemRepository = ticketItemRepository;
        }

        public async Task<ServiceResult<bool>> Handle(CreateTicketItemCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            var ticketItem = new Domain.Entities.TicketItem()
            {
                Status = 1,
                CreateDateTime = DateTime.UtcNow,
                Descriptions = request.Description,
                Title = request.Title,
                IsDeleted = false,
                IsAnswer = false,
                TicketId = request.TicketId,
            };
            _ticketItemRepository.Add(ticketItem);

            var ticket =await _ticketRepository.GetAll().Where(x => x.Id == request.TicketId).FirstAsync();
            ticket.Status = 1;

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            return new ServiceResult<bool>(true);
        }
    }
}
