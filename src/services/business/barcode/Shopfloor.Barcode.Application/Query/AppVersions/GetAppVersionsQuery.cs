using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.AppVersions;
using Shopfloor.Barcode.Application.Parameters.AppVersions;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.AppVersions
{
    public class GetAppVersionsQuery : IRequest<PagedResponse<IReadOnlyList<AppVersionModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? FileId { get; set; }
        public int? Version { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class GetAppVersionsQueryHandler : IRequestHandler<GetAppVersionsQuery, PagedResponse<IReadOnlyList<AppVersionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IAppVersionRepository _repository;

        public GetAppVersionsQueryHandler(IMapper mapper,
            IAppVersionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<AppVersionModel>>> Handle(GetAppVersionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<AppVersionParameter>(request);
            return await _repository.GetModelPagedReponseAsync<AppVersionParameter, AppVersionModel>(validFilter);
        }
    }
}