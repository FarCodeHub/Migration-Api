using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.PersonLawyer.Models;
using Application.Interfaces;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands.PersonLawyer.Create
{
   public class CreatePersonLawyerCommand : IRequest<ServiceResult<Domain.Entities.PersonLawyer>>, IMapFrom<CreatePersonLawyerCommand>
    {

        public List<PersonLawyerModel> PersonLawyers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonLawyerModel, Domain.Entities.PersonLawyer>();

        }
    }

   public class CreatePersonLawyerCommandHandler : IRequestHandler<CreatePersonLawyerCommand, ServiceResult<Domain.Entities.PersonLawyer>>
   {
       private readonly IRepository<Domain.Entities.PersonLawyer> _personLawyerRepository;
       private readonly IRepository<Domain.Entities.PersonCondition> _personConditoinRepository;
       private readonly IRepository<Domain.Entities.Person> _personRepository;
        private readonly IMapper _mapper;
       private readonly IUnitOfWork _unitOfWork;

       public CreatePersonLawyerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Domain.Entities.PersonLawyer> personLawyerRepository, IRepository<PersonCondition> personConditoinRepository)
       {
          
           _mapper = mapper;
           _unitOfWork = unitOfWork;
           _personLawyerRepository = personLawyerRepository;
           _personConditoinRepository = personConditoinRepository;
       }


       public async Task<ServiceResult<Domain.Entities.PersonLawyer>> Handle(CreatePersonLawyerCommand request, CancellationToken cancellationToken)
       {
           await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
           foreach (var item in request.PersonLawyers)
           {
               var entities = _mapper.Map<List<Domain.Entities.PersonCondition>>(item.PersonConditions);
               _personConditoinRepository.AddRange(entities);

               var personLawyerEntity =_mapper.Map<Domain.Entities.PersonLawyer>(item);
               var personLawyer = _personLawyerRepository.Add(_mapper.Map<Domain.Entities.PersonLawyer>(personLawyerEntity));


           }

           var update = _personRepository.Get(request.PersonLawyers[0].PersonId);
            
          var updateEntity = _mapper.Map<Domain.Entities.Person>(update);
          updateEntity.Status = 3;
           _personRepository.Update(updateEntity);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
           return new ServiceResult<Domain.Entities.PersonLawyer>( true);

       }
   }
}
