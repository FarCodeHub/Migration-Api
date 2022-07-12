using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Attachment.Models;
using Application.Commands.Person;
using Application.Commands.Person.Create;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Commands.Attachment.Create
{
    public class CreateFileCommand : IRequest<ServiceResult<FileModel>>, IMapFrom<CreateFileCommand>
    {

        public string FileName { get; set; }
        public int UserId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFileCommand, Domain.Entities.Attachment>();

        }
    }

    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, ServiceResult<FileModel>>
    {

        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFileCommandHandler(  IMapper mapper, IUnitOfWork unitOfWork, IAttachmentRepository attachmentRepository)
        {
          
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _attachmentRepository = attachmentRepository;
        }


        public async Task<ServiceResult<FileModel>> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            //   var user = _userRepository.Get(request.UserId);

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

            
            
            var attachment = _attachmentRepository.Add(_mapper.Map<Domain.Entities.Attachment>(request));
 

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            var data = _mapper.Map<FileModel>(attachment.Entity);
            return new ServiceResult<FileModel>(data, true);

        }
    }
}
