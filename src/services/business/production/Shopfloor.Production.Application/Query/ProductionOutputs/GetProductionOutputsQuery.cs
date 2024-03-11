using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.ProductionOutputs;
using Shopfloor.Production.Application.Parameters.ProductionOutputs;
using Shopfloor.Production.Domain.Enums;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.ProductionOutputs
{
    public class GetProductionOutputsQuery : IRequest<PagedResponse<IReadOnlyList<ProductionOutputModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int? QCDefinitionId { get; set; }
        public int? FPPOOutputId { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? WFXExportDate { get; set; }
        public WFXExportStatus? WFXExportStatus { get; set; }
        public SaveStatus? Status { get; set; }
        public string StockMovementNo { get; set; }
        public decimal CaptureMeter { get; set; }
        public decimal ActualWeight { get; set; }
        public int TotalDefect { get; set; }
        public int TotalContDefect { get; set; }
        public int TotalPoint { get; set; }
        public int PointSquareMeter { get; set; }
        public int? WarpDensity { get; set; }
        public int? WeftDensity { get; set; }
        public int PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public bool SystemResult { get; set; }
        public bool UserResult { get; set; }
        public string Grade { get; set; }
        public decimal? WeightGM2 { get; set; }

        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetProductionOutputsQueryHandler : IRequestHandler<GetProductionOutputsQuery, PagedResponse<IReadOnlyList<ProductionOutputModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductionOutputRepository _repository;
        public GetProductionOutputsQueryHandler(IMapper mapper,
            IProductionOutputRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ProductionOutputModel>>> Handle(GetProductionOutputsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProductionOutputParameter>(request);
            return await _repository.GetModelPagedReponseAsync<ProductionOutputParameter, ProductionOutputModel>(validFilter);
        }
    }
}
