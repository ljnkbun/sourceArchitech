using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.FabricWeights;
using Shopfloor.Inspection.Application.Parameters.FabricWeights;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.FabricWeights
{
    public class GetFabricWeightsQuery : IRequest<PagedResponse<IReadOnlyList<FabricWeightModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetFabricWeightsQueryHandler : IRequestHandler<GetFabricWeightsQuery, PagedResponse<IReadOnlyList<FabricWeightModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFabricWeightRepository _repository;
        public GetFabricWeightsQueryHandler(IMapper mapper,
            IFabricWeightRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FabricWeightModel>>> Handle(GetFabricWeightsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FabricWeightParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(FabricWeightParameter.Code), nameof(FabricWeightParameter.Name) }.ToList());
            return await _repository.GetModelSingleQueryPagedReponseAsync<FabricWeightParameter, FabricWeightModel>(validFilter);
        }
    }
}
