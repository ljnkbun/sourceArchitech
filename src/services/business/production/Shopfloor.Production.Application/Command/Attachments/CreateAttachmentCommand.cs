using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.Attachments
{
    public class CreateAttachmentCommand : IRequest<Response<int>>
    {
        public int? ProductionOutputId { get; set; }
        public int? DefectCapturing100PointsId { get; set; }
        public int? DefectCapturing4PointsId { get; set; }
        public int? DefectCapturingStandardId { get; set; }
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
