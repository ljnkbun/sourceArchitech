using AutoMapper;

using MediatR;

using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.SupplierFiles;
using Shopfloor.Material.Application.Parameters.SupplierFiles;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.SupplierFiles
{
    public class GetSupplierFilesQuery : IRequest<PagedResponse<IReadOnlyList<SupplierFileModel>>>, ICacheableMediatrQuery
    {
        public int? SupplierId { get; set; }

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

        public string CacheKey => $"SupplierFiles";

        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Default properties
    }

    public class GetSupplierFilesQueryHandler : IRequestHandler<GetSupplierFilesQuery, PagedResponse<IReadOnlyList<SupplierFileModel>>>
    {
        private readonly IMapper _mapper;

        private readonly ISupplierFileRepository _repository;

        public GetSupplierFilesQueryHandler(IMapper mapper,
            ISupplierFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SupplierFileModel>>> Handle(GetSupplierFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SupplierFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SupplierFileParameter, SupplierFileModel>(validFilter);
        }
    }
}