using MediatR;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<ServiceResult<UserModel>>, IMapFrom<CreateUserCommand>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommand, Domain.Entities.User>();
        }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResult<UserModel>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IMapper mapper, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<UserModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
            var opt = _mapper.Map<Domain.Entities.User>(request);
            var entity = _userRepository.Add(opt);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            var data = _mapper.Map<UserModel>(entity.Entity);
            return new ServiceResult<UserModel>(data, true);

        }
    }
}

