using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class DeletePersonCommand : IRequest<ServiceResult>, IMapFrom<DeletePersonCommand>
    {

        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeletePersonCommand, Domain.Entities.Person>();

        }
    }

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, ServiceResult>
    {
        private readonly IRepository<Person> _personRepository;
   
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(IRepository<Person> personRepository, IMapper mapper, IUnitOfWork unitOfWork )
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
      
        }


        public async Task<ServiceResult> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            var entity =await _personRepository.Get(request.Id);
            entity.Status = 2;
              _personRepository.Update(entity);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
         
            return new ServiceResult( true);

        }
    }
}

 
