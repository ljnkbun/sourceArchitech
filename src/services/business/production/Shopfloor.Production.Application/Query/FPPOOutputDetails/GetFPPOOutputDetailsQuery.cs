using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.FPPOOutputDetails;
using Shopfloor.Production.Application.Parameters.FPPOOutputDetails;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.FPPOOutputDetails
{
    public class GetFPPOOutputDetailsQuery : IRequest<PagedResponse<IReadOnlyList<FPPOOutputDetailModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public int? FPPOOutputId { get; set; }
        public decimal? PlannedQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BalanceQty { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetFPPOOutputDetailsQueryHandler : IRequestHandler<GetFPPOOutputDetailsQuery, PagedResponse<IReadOnlyList<FPPOOutputDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFPPOOutputDetailRepository _repository;
        public GetFPPOOutputDetailsQueryHandler(IMapper mapper,
            IFPPOOutputDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FPPOOutputDetailModel>>> Handle(GetFPPOOutputDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FPPOOutputDetailParameter>(request);
            return await _repository.GetModelPagedReponseAsync<FPPOOutputDetailParameter, FPPOOutputDetailModel>(validFilter);
        }
    }
}
