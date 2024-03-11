using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingProcessChemicals;
using Shopfloor.IED.Application.Parameters.DyeingProcessChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingProcessChemicals
{
    public class GetDyeingProcessChemicalsQuery : IRequest<PagedResponse<IReadOnlyList<DyeingProcessChemicalModel>>>
    {
        public int? DyeingRoutingId { get; set; }

        public string ChemicalCode { get; set; }

        public string ChemicalName { get; set; }

        public string SubCategoryCode { get; set; }

        public string SubCategoryName { get; set; }

        public decimal? Quantity { get; set; }

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

        #endregion Base Properties
    }

    public class GetDyeingProcessChemicalsQueryHandler : IRequestHandler<GetDyeingProcessChemicalsQuery, PagedResponse<IReadOnlyList<DyeingProcessChemicalModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingProcessChemicalRepository _repository;

        public GetDyeingProcessChemicalsQueryHandler(IMapper mapper,
            IDyeingProcessChemicalRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingProcessChemicalModel>>> Handle(GetDyeingProcessChemicalsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingProcessChemicalParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingProcessChemicalParameter, DyeingProcessChemicalModel>(validFilter);
        }
    }
}