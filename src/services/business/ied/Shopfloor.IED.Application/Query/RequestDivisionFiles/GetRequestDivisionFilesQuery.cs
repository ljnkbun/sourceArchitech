using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RequestDivisionFiles;
using Shopfloor.IED.Application.Parameters.RequestDivisionFiles;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestDivisionFiles
{
    public class GetRequestDivisionFilesQuery : IRequest<PagedResponse<IReadOnlyList<RequestDivisionFileModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? RequestDivisionId { get; set; }
        public FileType? FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"RequestDivisionFiles";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetRequestDivisionFilesQueryHandler : IRequestHandler<GetRequestDivisionFilesQuery, PagedResponse<IReadOnlyList<RequestDivisionFileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestDivisionFileRepository _repository;
        public GetRequestDivisionFilesQueryHandler(IMapper mapper,
            IRequestDivisionFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RequestDivisionFileModel>>> Handle(GetRequestDivisionFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RequestDivisionFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RequestDivisionFileParameter, RequestDivisionFileModel>(validFilter);
        }
    }
}
