using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.Attachments;
using Shopfloor.Inspection.Application.Parameters.Attachments;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.Attachments
{
    public class GetAttachmentsQuery : IRequest<PagedResponse<IReadOnlyList<AttachmentModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? InspectionId { get; set; }
        public int? Inpection4PointSysId { get; set; }
        public int? Inpection100PointSysId { get; set; }
        public int? InpectionTCStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType? FileType { get; set; }
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
