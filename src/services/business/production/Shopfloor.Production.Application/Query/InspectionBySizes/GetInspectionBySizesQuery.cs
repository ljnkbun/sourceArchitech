using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.InspectionBySizes;
using Shopfloor.Production.Application.Parameters.InspectionBySizes;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.InspectionBySizes
{
    public class GetInspectionBySizesQuery : IRequest<PagedResponse<IReadOnlyList<InspectionBySizeModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int? ProductionOutputId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public int? FPPOOutputDetailId { get; set; }
        public decimal? OKQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BGroupQty { get; set; }
        public decimal? RejectQty { get; set; }
        public decimal? Length { get; set; }
        public decimal? Weight { get; set; }
        public decimal? ActualWeight { get; set; }
        public decimal? CaptureMeter { get; set; }
        public decimal? CuttingWidth { get; set; }
        public decimal? WarpDensity { get; set; }
        public decimal? WeftDensity { get; set; }


        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetInspectionBySizesQueryHandler : IRequestHandler<GetInspectionBySizesQuery, PagedResponse<IReadOnlyList<InspectionBySizeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IInspectionBySizeRepository _repository;
        public GetInspectionBySizesQueryHandler(IMapper mapper,
            IInspectionBySizeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<InspectionBySizeModel>>> Handle(GetInspectionBySizesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<InspectionBySizeParameter>(request);
            return await _repository.GetModelPagedReponseAsync<InspectionBySizeParameter, InspectionBySizeModel>(validFilter);
        }
    }
}
