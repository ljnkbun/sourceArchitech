using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBRChemicals;
using Shopfloor.IED.Application.Parameters.DyeingTBRChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRChemicals
{
    public class GetDyeingTBRChemicalsQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBRChemicalModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBRTaskId { get; set; }
        public int? ChemicalId { get; set; }
        public string ChemicalCode { get; set; }
        public string ChemicalName { get; set; }
        public string Unit { get; set; }

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
        public string CacheKey => $"DyeingTBRChemicals";
        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBRChemicalsQueryHandler : IRequestHandler<GetDyeingTBRChemicalsQuery, PagedResponse<IReadOnlyList<DyeingTBRChemicalModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRChemicalRepository _repository;

        public GetDyeingTBRChemicalsQueryHandler(IMapper mapper,
            IDyeingTBRChemicalRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBRChemicalModel>>> Handle(GetDyeingTBRChemicalsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBRChemicalParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingTBRChemicalParameter, DyeingTBRChemicalModel>(validFilter);
        }
    }
}