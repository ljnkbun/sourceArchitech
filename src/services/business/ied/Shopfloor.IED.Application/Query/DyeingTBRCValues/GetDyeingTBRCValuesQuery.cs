using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBRCValues;
using Shopfloor.IED.Application.Parameters.DyeingTBRCValues;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRCValues
{
    public class GetDyeingTBRCValuesQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBRCValueModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBRChemicalId { get; set; }

        public int? DyeingTBRVersionId { get; set; }

        public decimal? Value { get; set; }

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
        public string CacheKey => $"DyeingTBRCValues";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBRCValuesQueryHandler : IRequestHandler<GetDyeingTBRCValuesQuery, PagedResponse<IReadOnlyList<DyeingTBRCValueModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRCValueRepository _repository;

        public GetDyeingTBRCValuesQueryHandler(IMapper mapper,
            IDyeingTBRCValueRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBRCValueModel>>> Handle(GetDyeingTBRCValuesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBRCValueParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingTBRCValueParameter, DyeingTBRCValueModel>(validFilter);
        }
    }
}