using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Commands.Person.Create
{
    public class CreatePersonCommand : IRequest<ServiceResult<PersonModel>>,IMapFrom<CreatePersonCommand>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
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
        private readonly IPersonRepository _personRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVisaRepository _visaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository, IVisaRepository visaRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _visaRepository = visaRepository;
        }


        public async Task<ServiceResult<PersonModel>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
         //   var user = _userRepository.Get(request.UserId);

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

            var person =  _personRepository.Add(_mapper.Map<Domain.Entities.Person>(request));
            
          //   var visa = _visaRepository.Add(_mapper.Map<Domain.Entities.Visa>(request));

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            var data = _mapper.Map<PersonModel>(person.Entity);
            return new ServiceResult<PersonModel>(data, true);

        }
    }
}
