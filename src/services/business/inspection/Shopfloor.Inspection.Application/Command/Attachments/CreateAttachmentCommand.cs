using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.Attachments
{
    public class CreateAttachmentCommand : IRequest<Response<int>>
    {
        public int? InspectionId { get; set; }
        public int? Inpection4PointSysId { get; set; }
        public int? Inpection100PointSysId { get; set; }
        public int? InpectionTCStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType FileType { get; set; }
    }
    public class CreateAttachmentCommandHandler : IRequestHandler<CreateAttachmentCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAttachmentRepository _repository;
        public CreateAttachmentCommandHandler(IMapper mapper,
            IAttachmentRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Attachment>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
