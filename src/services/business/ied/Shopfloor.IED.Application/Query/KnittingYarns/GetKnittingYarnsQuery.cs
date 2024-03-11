using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingYarns;
using Shopfloor.IED.Application.Parameters.KnittingYarns;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingYarns
{
    public class GetKnittingYarnsQuery : IRequest<PagedResponse<IReadOnlyList<KnittingYarnModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? KnittingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public int? WFXYarnId { get; set; }
        public string YarnName { get; set; }
        public string YarnCode { get; set; }
        public string Color { get; set; }
        public decimal? YarnRatio { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Wastage { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetKnittingYarnsQueryHandler : IRequestHandler<GetKnittingYarnsQuery, PagedResponse<IReadOnlyList<KnittingYarnModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingYarnRepository _repository;
        public GetKnittingYarnsQueryHandler(IMapper mapper,
            IKnittingYarnRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<KnittingYarnModel>>> Handle(GetKnittingYarnsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<KnittingYarnParameter>(request);
            return await _repository.GetModelPagedReponseAsync<KnittingYarnParameter, KnittingYarnModel>(validFilter);
        }
    }
}
