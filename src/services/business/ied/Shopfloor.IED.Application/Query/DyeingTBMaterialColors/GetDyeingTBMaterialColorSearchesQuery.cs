using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBMaterialColors;
using Shopfloor.IED.Application.Parameters.DyeingTBMaterialColors;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBMaterialColors
{
    public class GetDyeingTBMaterialColorSearchesQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBMaterialColorModel>>>, ICacheableMediatrQuery
    {
        public string RequestNo { get; set; }

        public string ArticleCode { get; set; }

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
        public string CacheKey => $"DyeingTBMaterialColorSearches";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBMaterialColorSearchesQueryHandler : IRequestHandler<GetDyeingTBMaterialColorSearchesQuery, PagedResponse<IReadOnlyList<DyeingTBMaterialColorModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBMaterialColorRepository _repository;

        public GetDyeingTBMaterialColorSearchesQueryHandler(IMapper mapper,
            IDyeingTBMaterialColorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBMaterialColorModel>>> Handle(GetDyeingTBMaterialColorSearchesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBMaterialColorSearchParameter>(request);
            return await _repository.GetMaterialColorPagedResponseAsync<DyeingTBMaterialColorSearchParameter, DyeingTBMaterialColorModel>(validFilter);
        }
    }
}