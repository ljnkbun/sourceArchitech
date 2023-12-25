using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBRVersions;
using Shopfloor.IED.Application.Parameters.DyeingTBRVersions;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRVersions
{
    public class GetDyeingTBRVersionsQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBRVersionModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBRecipeId { get; set; }

        public int? Version { get; set; }

        public DateTime? DoTime { get; set; }

        public bool? Approved { get; set; }

        #region Base Properties

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"DyeingTBRVersions";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBRVersionsQueryHandler : IRequestHandler<GetDyeingTBRVersionsQuery, PagedResponse<IReadOnlyList<DyeingTBRVersionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRVersionRepository _repository;

        public GetDyeingTBRVersionsQueryHandler(IMapper mapper,
            IDyeingTBRVersionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBRVersionModel>>> Handle(GetDyeingTBRVersionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBRVersionParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingTBRVersionParameter, DyeingTBRVersionModel>(validFilter);
        }
    }
}