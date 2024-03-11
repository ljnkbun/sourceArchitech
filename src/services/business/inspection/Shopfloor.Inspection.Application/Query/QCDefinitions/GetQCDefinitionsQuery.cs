using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Application.Parameters.QCDefinitions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Query.QCDefinitions
{
    public class GetQCDefinitionsQuery : IRequest<PagedResponse<IReadOnlyList<QCDefinitionModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public decimal? AcceptanceValue { get; set; }
		public int? SamplingId { get; set; }
		public int? ConversionId { get; set; }
        public int? QCTypeId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public decimal? PercentQC { get; set; }
        public decimal? PercentAcceptance { get; set; }
        public decimal? FixedQty { get; set; }
        public decimal? AcceptanceQty { get; set; }
        public decimal? Quantity { get; set; }
        public int? AQLVersionId { get; set; }
        public int? FourPointsSystemId { get; set; }
        public int? OneHundredPointSystemId { get; set; }
    }
    public class GetQCDefinitionsQueryHandler : IRequestHandler<GetQCDefinitionsQuery, PagedResponse<IReadOnlyList<QCDefinitionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IQCDefinitionRepository _repository;
        public GetQCDefinitionsQueryHandler(IMapper mapper,
            IQCDefinitionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<QCDefinitionModel>>> Handle(GetQCDefinitionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<QCDefinitionParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(QCDefinitionParameter.Code), nameof(QCDefinitionParameter.Name) }.ToList());
            return await _repository.GetModelSingleQueryPagedReponseAsync<QCDefinitionParameter, QCDefinitionModel>(validFilter);
        }
    }
}
