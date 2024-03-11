using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingRusticFabricSpecs;
using Shopfloor.IED.Application.Parameters.WeavingRusticFabricSpecs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRusticFabricSpecs
{
    public class GetWeavingRusticFabricSpecsQuery : IRequest<PagedResponse<IReadOnlyList<WeavingRusticFabricSpecModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingIEDId { get; set; }
        public int? LineNumber { get; set; }
        public string ContentWeaveStyle { get; set; }
        public decimal? HarnessFrameCWS { get; set; }
        public string MarginWeaveStyle { get; set; }
        public decimal? HarnessFrameMWS { get; set; }
        public decimal? WeightGM { get; set; }
        public decimal? WeightGM2 { get; set; }
        public decimal? WarpShrinkage { get; set; }
        public decimal? WeftShrinkage { get; set; }
        public string MachineType { get; set; }
        public decimal? RPM { get; set; }
        public decimal? ReedCount { get; set; }
        public decimal? ReedWidth { get; set; }
        public decimal? WarpDensity { get; set; }
        public decimal? WeftDensity { get; set; }
        public decimal? GreigeWidth { get; set; }
        public decimal? SettingWeftDensity { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetWeavingRusticFabricSpecsQueryHandler : IRequestHandler<GetWeavingRusticFabricSpecsQuery, PagedResponse<IReadOnlyList<WeavingRusticFabricSpecModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRusticFabricSpecRepository _repository;
        public GetWeavingRusticFabricSpecsQueryHandler(IMapper mapper,
            IWeavingRusticFabricSpecRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingRusticFabricSpecModel>>> Handle(GetWeavingRusticFabricSpecsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingRusticFabricSpecParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingRusticFabricSpecParameter, WeavingRusticFabricSpecModel>(validFilter);
        }
    }
}
