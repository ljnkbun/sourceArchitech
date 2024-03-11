using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.Requests;
using Shopfloor.IED.Application.Parameters.Requests;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Requests
{
    public class GetRequestsQuery : IRequest<PagedResponse<IReadOnlyList<RequestModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string RequestNo { get; set; }
        public string Description { get; set; }
        public RequestStatus? Status { get; set; }
        public string StatusComment { get; set; }
        public decimal? ExpectedQty { get; set; }
        public int? RequestTypeId { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetRequestsQueryHandler : IRequestHandler<GetRequestsQuery, PagedResponse<IReadOnlyList<RequestModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _repository;
        public GetRequestsQueryHandler(IMapper mapper,
            IRequestRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RequestModel>>> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RequestIEDParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RequestIEDParameter, RequestModel>(validFilter);
        }
    }
}
