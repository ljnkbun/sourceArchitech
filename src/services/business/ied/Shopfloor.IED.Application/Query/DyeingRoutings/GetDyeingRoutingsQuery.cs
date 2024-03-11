using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingRoutings;
using Shopfloor.IED.Application.Parameters.DyeingRoutings;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingRoutings
{
    public class GetDyeingRoutingsQuery : IRequest<PagedResponse<IReadOnlyList<DyeingRoutingModel>>>
    {
        public int? DyeingIEDId { get; set; }

        public int? LineNumber { get; set; }

        public string DyeingProcess { get; set; }

        public string DyeingProcessCode { get; set; }

        public string DyeingOperation { get; set; }

        public string DyeingOperationCode { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal? Efficiency { get; set; }

        public decimal? MachineTime { get; set; }

        public decimal? Temperature { get; set; }

        public decimal? OperationTime { get; set; }

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

    public class GetDyeingRoutingsQueryHandler : IRequestHandler<GetDyeingRoutingsQuery, PagedResponse<IReadOnlyList<DyeingRoutingModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingRoutingRepository _repository;

        public GetDyeingRoutingsQueryHandler(IMapper mapper,
            IDyeingRoutingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingRoutingModel>>> Handle(GetDyeingRoutingsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingRoutingParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingRoutingParameter, DyeingRoutingModel>(validFilter);
        }
    }
}