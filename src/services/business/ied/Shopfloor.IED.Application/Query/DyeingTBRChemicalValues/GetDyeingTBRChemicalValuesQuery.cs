using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBRChemicalValues;
using Shopfloor.IED.Application.Parameters.DyeingTBRChemicalValues;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRChemicalValues
{
    public class GetDyeingTBRChemicalValuesQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBRChemicalValueModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBRChemicalId { get; set; }

        public int? VersionIndex { get; set; }

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
        public string CacheKey => $"DyeingTBRChemicalValues";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBRChemicalValuesQueryHandler : IRequestHandler<GetDyeingTBRChemicalValuesQuery, PagedResponse<IReadOnlyList<DyeingTBRChemicalValueModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRChemicalValueRepository _repository;

        public GetDyeingTBRChemicalValuesQueryHandler(IMapper mapper,
            IDyeingTBRChemicalValueRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBRChemicalValueModel>>> Handle(GetDyeingTBRChemicalValuesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBRChemicalValueParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingTBRChemicalValueParameter, DyeingTBRChemicalValueModel>(validFilter);
        }
    }
}