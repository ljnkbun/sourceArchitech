using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBMaterialColors;
using Shopfloor.IED.Application.Parameters.DyeingTBMaterialColors;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBMaterialColors
{
    public class GetDyeingTBMaterialColorsQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBMaterialColorModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBMaterialId { get; set; }

        public string Color { get; set; }

        public string Pantone { get; set; }

        public TBMaterialColorStatus? Status { get; set; }

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
        public string CacheKey => $"DyeingTBMaterialColors";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBMaterialColorsQueryHandler : IRequestHandler<GetDyeingTBMaterialColorsQuery, PagedResponse<IReadOnlyList<DyeingTBMaterialColorModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBMaterialColorRepository _repository;

        public GetDyeingTBMaterialColorsQueryHandler(IMapper mapper,
            IDyeingTBMaterialColorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBMaterialColorModel>>> Handle(GetDyeingTBMaterialColorsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBMaterialColorParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingTBMaterialColorParameter, DyeingTBMaterialColorModel>(validFilter);
        }
    }
}