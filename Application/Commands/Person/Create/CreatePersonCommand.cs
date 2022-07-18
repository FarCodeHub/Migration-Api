using System;
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
    public class CreatePersonCommand : IRequest<ServiceResult<PersonModel>>,IMapFrom<CreatePersonCommand>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; } = 1;
        public string Country { get; set; }
        public string IsMarried { get; set; }  
        public string VisaType { get; set; }
        public string VisaStatus { get; set; }
        public DateTime VisaExpirationDate { get; set; }
        public string FilePath { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePersonCommand, Domain.Entities.Person>();

        }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ServiceResult<PersonModel>>
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<User> _useRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonCommandHandler(IRepository<Person> personRepository, IMapper mapper, IUnitOfWork unitOfWork, IRepository<User> useRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _useRepository = useRepository;
        }


        public async Task<ServiceResult<PersonModel>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
         //   var user = _userRepository.Get(request.UserId);

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

            var person =  _personRepository.Add(_mapper.Map<Domain.Entities.Person>(request));
            var user = _useRepository.Get(request.UserId);
            var updateEntity = _mapper.Map<Domain.Entities.User>(user);
            updateEntity.Person = person.Entity;
            _useRepository.Update(updateEntity);

            //   var visa = _visaRepository.Add(_mapper.Map<Domain.Entities.Visa>(request));

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            var data = _mapper.Map<PersonModel>(person.Entity);
            return new ServiceResult<PersonModel>(data, true);

        }
    }
}
