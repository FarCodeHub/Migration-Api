using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Commands.Person.Delete
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
        private readonly IPersonRepository _personRepository;
   
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork )
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
      
        }


        public async Task<ServiceResult> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            var entity =await _personRepository.Get(request.Id);
              _personRepository.Remove(entity);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
         
            return new ServiceResult( true);

        }
    }
}

 
