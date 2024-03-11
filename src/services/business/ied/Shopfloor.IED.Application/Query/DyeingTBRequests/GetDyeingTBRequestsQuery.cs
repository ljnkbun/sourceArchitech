using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBRequests;
using Shopfloor.IED.Application.Parameters.DyeingTBRequests;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRequests
{
    public class GetDyeingTBRequestsQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBRequestModel>>>
    {
        public string RequestNo { get; set; }

        public int? RecipeCategoryId { get; set; }

        public DateTime? RequestDate { get; set; }

        public string StyleRef { get; set; }

        public string Remark { get; set; }

        public int? DyeingIEDId { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public TBRequestStatus? Status { get; set; }

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

    public class GetDyeingTBRequestsQueryHandler : IRequestHandler<GetDyeingTBRequestsQuery, PagedResponse<IReadOnlyList<DyeingTBRequestModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRequestRepository _repository;

        public GetDyeingTBRequestsQueryHandler(IMapper mapper,
            IDyeingTBRequestRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBRequestModel>>> Handle(GetDyeingTBRequestsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBRequestParameter>(request);
            return await _repository.GetRequestPagedResponseAsync<DyeingTBRequestParameter, DyeingTBRequestModel>(validFilter);
        }
    }
}