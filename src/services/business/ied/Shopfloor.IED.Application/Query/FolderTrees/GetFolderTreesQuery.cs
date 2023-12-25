using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.FolderTrees;
using Shopfloor.IED.Application.Parameters.FolderTrees;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.FolderTrees
{
    public class GetFolderTreesQuery : IRequest<PagedResponse<IReadOnlyList<FolderTreeModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public byte? Level { get; set; }
        public int? ParentId { get; set; }
        public ItemType? ItemType { get; set; }
        public DivisionType? DivisionType { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"FolderTrees";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFolderTreesQueryHandler : IRequestHandler<GetFolderTreesQuery, PagedResponse<IReadOnlyList<FolderTreeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFolderTreeRepository _repository;
        public GetFolderTreesQueryHandler(IMapper mapper,
            IFolderTreeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FolderTreeModel>>> Handle(GetFolderTreesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FolderTreeParameter>(request);
            return await _repository.GetModelPagedReponseAsync<FolderTreeParameter, FolderTreeModel>(validFilter);
        }
    }
}
