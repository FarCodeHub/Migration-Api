using Application.Wrapper;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.LawyerCondition.Model;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Commands.LawyerCondition.Create
{
   public class CreateLawyerConditionCommand : IRequest<ServiceResult<LawyerConditionModel>>, IMapFrom<CreateLawyerConditionCommand>
    {
        public int LawyerId { get; set; }
        public string Condition { get; set; }
        public bool IsAccepted { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLawyerConditionCommand, Domain.Entities.LawyerCondition>();

        }
    }

    public class CreateLawyerConditionCommandHandler : IRequestHandler<CreateLawyerConditionCommand, ServiceResult<LawyerConditionModel>>
    {

        private readonly ILawyerConditionRepository _lawyerConditionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLawyerConditionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ILawyerConditionRepository lawyerConditionRepository)
        {
            
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _lawyerConditionRepository = lawyerConditionRepository;
        }


        public async Task<ServiceResult<LawyerConditionModel>> Handle(CreateLawyerConditionCommand request, CancellationToken cancellationToken)
        {

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

            var lawyer = _lawyerConditionRepository
                .Add(_mapper.Map<Domain.Entities.LawyerCondition>(request));

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            var data = _mapper.Map<LawyerConditionModel>(lawyer.Entity);
            return new ServiceResult<LawyerConditionModel>(data, true);

        }
    }
}

