using Application.Wrapper;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Domain.Entities;

namespace Application.Commands
{
   public class PersonConditionCommand : IRequest<ServiceResult<LawyerConditionModel>>, IMapFrom<PersonConditionCommand>
    {
        public int LawyerId { get; set; }
        public string Condition { get; set; }
        public bool IsAccepted { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonConditionCommand, Domain.Entities.LawyerCondition>();

        }
    }

    public class PersonConditionCommandHandler : IRequestHandler<PersonConditionCommand, ServiceResult<LawyerConditionModel>>
    {

        private readonly IRepository<PersonCondition> _personConditionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonConditionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IRepository<PersonCondition> personConditionRepository)
        {
            
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personConditionRepository = personConditionRepository;
        }


        public async Task<ServiceResult<LawyerConditionModel>> Handle(PersonConditionCommand request, CancellationToken cancellationToken)
        {

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

            var lawyer = _personConditionRepository
                .Add(_mapper.Map<Domain.Entities.PersonCondition>(request));

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            var data = _mapper.Map<LawyerConditionModel>(lawyer.Entity);
            return new ServiceResult<LawyerConditionModel>(data, true);

        }
    }
}

