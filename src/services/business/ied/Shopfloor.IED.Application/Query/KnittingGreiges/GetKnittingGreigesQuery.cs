using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingGreiges;
using Shopfloor.IED.Application.Parameters.KnittingGreiges;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingGreiges
{
    public class GetKnittingGreigesQuery : IRequest<PagedResponse<IReadOnlyList<KnittingGreigeModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? KnittingIEDId { get; set; }
        public int? KnittingBodyTypeId { get; set; }
        public int? KnittingTypeId { get; set; }
        public decimal? Width { get; set; }
        public decimal? WidthLossRate { get; set; }
        public decimal? WeightGM { get; set; }
        public decimal? WeightGMLossRate { get; set; }
        public decimal? VerticalDensity { get; set; }
        public decimal? VerticalDensityLossRate { get; set; }
        public decimal? HorizontalDensity { get; set; }
        public decimal? HorizontalDensityLossRate { get; set; }
        public decimal? WrapShrinkage { get; set; }
        public int? KnittingShrinkageId { get; set; }
        public decimal? WeftShrinkage { get; set; }
        public int? Gauge { get; set; }
        public decimal? Feeder { get; set; }
        public decimal? UsedFeeder { get; set; }
        public decimal? Needle { get; set; }
        public decimal? RappoLength { get; set; }
        public decimal? MachineDiameter { get; set; }
        public decimal? WeightKg { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetKnittingGreigesQueryHandler : IRequestHandler<GetKnittingGreigesQuery, PagedResponse<IReadOnlyList<KnittingGreigeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingGreigeRepository _repository;
        public GetKnittingGreigesQueryHandler(IMapper mapper,
            IKnittingGreigeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<KnittingGreigeModel>>> Handle(GetKnittingGreigesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<KnittingGreigeParameter>(request);
            return await _repository.GetModelPagedReponseAsync<KnittingGreigeParameter, KnittingGreigeModel>(validFilter);
        }
    }
}
