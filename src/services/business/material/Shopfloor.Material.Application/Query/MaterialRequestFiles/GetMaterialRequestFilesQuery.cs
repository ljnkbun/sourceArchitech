using AutoMapper;

using MediatR;

using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.MaterialRequestFiles;
using Shopfloor.Material.Application.Parameters.MaterialRequestFiles;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.MaterialRequestFiles
{
    public class GetMaterialRequestFilesQuery : IRequest<PagedResponse<IReadOnlyList<MaterialRequestFileModel>>>, ICacheableMediatrQuery
    {
        public int? MaterialRequestId { get; set; }

        public FileType? FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }

        #region Default properties

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string SearchTerm { get; set; }

        public string OrderBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? CreatedUserId { get; set; }

        public Guid? ModifiedUserId { get; set; }

        public bool? IsActive { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => $"MaterialRequestFiles";

        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Default properties
    }

    public class GetMaterialRequestFilesQueryHandler : IRequestHandler<GetMaterialRequestFilesQuery, PagedResponse<IReadOnlyList<MaterialRequestFileModel>>>
    {
        private readonly IMapper _mapper;

        private readonly IMaterialRequestFileRepository _repository;

        public GetMaterialRequestFilesQueryHandler(IMapper mapper,
            IMaterialRequestFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<MaterialRequestFileModel>>> Handle(GetMaterialRequestFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MaterialRequestFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<MaterialRequestFileParameter, MaterialRequestFileModel>(validFilter);
        }
    }
}