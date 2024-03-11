using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.Attachments;
using Shopfloor.Production.Application.Parameters.Attachments;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.Attachments
{
    public class GetAttachmentsQuery : IRequest<PagedResponse<IReadOnlyList<AttachmentModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int? ProductionOutputId { get; set; }
        public int? DefectCapturing100PointsId { get; set; }
        public int? DefectCapturing4PointsId { get; set; }
        public int? DefectCapturingStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType FileType { get; set; }


        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetAttachmentsQueryHandler : IRequestHandler<GetAttachmentsQuery, PagedResponse<IReadOnlyList<AttachmentModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IAttachmentRepository _repository;
        public GetAttachmentsQueryHandler(IMapper mapper,
            IAttachmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<AttachmentModel>>> Handle(GetAttachmentsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<AttachmentParameter>(request);
            return await _repository.GetModelPagedReponseAsync<AttachmentParameter, AttachmentModel>(validFilter);
        }
    }
}
