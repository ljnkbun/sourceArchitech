using AutoMapper;

using MediatR;

using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.BuyerFiles;
using Shopfloor.Material.Application.Parameters.BuyerFiles;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.BuyerFiles
{
    public class GetBuyerFilesQuery : IRequest<PagedResponse<IReadOnlyList<BuyerFileModel>>>, ICacheableMediatrQuery
    {
        public int? BuyerId { get; set; }

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

        public string CacheKey => $"BuyerFiles";

        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Default properties
    }

    public class GetBuyerFilesQueryHandler : IRequestHandler<GetBuyerFilesQuery, PagedResponse<IReadOnlyList<BuyerFileModel>>>
    {
        private readonly IMapper _mapper;

        private readonly IBuyerFileRepository _repository;

        public GetBuyerFilesQueryHandler(IMapper mapper,
            IBuyerFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<BuyerFileModel>>> Handle(GetBuyerFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<BuyerFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<BuyerFileParameter, BuyerFileModel>(validFilter);
        }
    }
}