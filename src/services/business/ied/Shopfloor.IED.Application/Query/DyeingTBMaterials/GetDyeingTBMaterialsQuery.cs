using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBMaterials;
using Shopfloor.IED.Application.Parameters.DyeingTBMaterials;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBMaterials
{
    public class GetDyeingTBMaterialsQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBMaterialModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBRequestId { get; set; }

        public string ArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string MaterialType { get; set; }

        public string FabricContent { get; set; }

        public string Lights { get; set; }

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
        public string CacheKey => $"DyeingTBMaterials";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBMaterialsQueryHandler : IRequestHandler<GetDyeingTBMaterialsQuery, PagedResponse<IReadOnlyList<DyeingTBMaterialModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBMaterialRepository _repository;

        public GetDyeingTBMaterialsQueryHandler(IMapper mapper,
            IDyeingTBMaterialRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBMaterialModel>>> Handle(GetDyeingTBMaterialsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBMaterialParameter>(request);
            return await _repository.GetMaterialPagedResponseAsync<DyeingTBMaterialParameter, DyeingTBMaterialModel>(validFilter);
        }
    }
}