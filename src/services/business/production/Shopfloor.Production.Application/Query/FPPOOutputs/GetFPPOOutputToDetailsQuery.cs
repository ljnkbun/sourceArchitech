using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.FPPOOutputs;
using Shopfloor.Production.Application.Parameters.FPPOOutputs;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.FPPOOutputs
{
    public class GetFPPOOutputToDetailsQuery : IRequest<PagedResponse<IReadOnlyList<FPPOOutputToDetailsModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string OCNo { get; set; }
        public string ArticleName { get; set; }
        public string BatchNo { get; set; }
        public string JobOrderNo { get; set; }
        public string FPPONo { get; set; }
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
    public class GetFPPOOutputToDetailsQueryHandler : IRequestHandler<GetFPPOOutputToDetailsQuery, PagedResponse<IReadOnlyList<FPPOOutputToDetailsModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFPPOOutputDetailRepository _repository;
        public GetFPPOOutputToDetailsQueryHandler(IMapper mapper,
            IFPPOOutputDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FPPOOutputToDetailsModel>>> Handle(GetFPPOOutputToDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FPPOOutputToDetailsParameter>(request);
            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;
            var rs = await _repository.GetCustomModelPagedReponseAsync<FPPOOutputToDetailsParameter, FPPOOutputToDetailsModel>(validFilter, validFilter.OCNo, validFilter.ArticleName, validFilter.JobOrderNo, validFilter.BatchNo, validFilter.FPPONo, validFilter.PlannedQty, validFilter.Size, validFilter.Color);

            return rs;
        }
    }
}
