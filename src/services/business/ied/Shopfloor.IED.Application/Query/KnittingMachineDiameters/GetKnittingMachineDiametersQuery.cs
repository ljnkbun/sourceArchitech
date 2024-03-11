using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingMachineDiameters;
using Shopfloor.IED.Application.Parameters.KnittingMachineDiameters;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingMachineDiameters
{
    public class GetKnittingMachineDiametersQuery : IRequest<PagedResponse<IReadOnlyList<KnittingMachineDiameterModel>>>
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
    public class GetKnittingMachineDiametersQueryHandler : IRequestHandler<GetKnittingMachineDiametersQuery, PagedResponse<IReadOnlyList<KnittingMachineDiameterModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingMachineDiameterRepository _repository;
        public GetKnittingMachineDiametersQueryHandler(IMapper mapper,
            IKnittingMachineDiameterRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<KnittingMachineDiameterModel>>> Handle(GetKnittingMachineDiametersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<KnittingMachineDiameterParameter>(request);
            return await _repository.GetModelPagedReponseAsync<KnittingMachineDiameterParameter, KnittingMachineDiameterModel>(validFilter);
        }
    }
}
