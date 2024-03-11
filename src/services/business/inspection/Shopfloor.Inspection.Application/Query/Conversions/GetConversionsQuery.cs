using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Application.Models.Conversions;
using Shopfloor.Inspection.Application.Parameters.Conversions;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.Conversions
{
    public class GetConversionsQuery : IRequest<PagedResponse<IReadOnlyList<ConversionModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }

        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetConversionsQueryHandler : IRequestHandler<GetConversionsQuery, PagedResponse<IReadOnlyList<ConversionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IConversionRepository _repository;
        public GetConversionsQueryHandler(IMapper mapper,
            IConversionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ConversionModel>>> Handle(GetConversionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ConversionParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ConversionParameter.Code), nameof(ConversionParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ConversionParameter, ConversionModel>(validFilter);
        }
    }
}
