using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.FormulaFields;
using Shopfloor.IED.Application.Parameters.FormulaFields;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.FormulaFields
{
    public class GetFormulaFieldsQuery : IRequest<PagedResponse<IReadOnlyList<FormulaFieldModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }
        public string ProcessCode { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"FormulaFields";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFormulaFieldsQueryHandler : IRequestHandler<GetFormulaFieldsQuery, PagedResponse<IReadOnlyList<FormulaFieldModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFormulaFieldRepository _repository;
        public GetFormulaFieldsQueryHandler(IMapper mapper,
            IFormulaFieldRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FormulaFieldModel>>> Handle(GetFormulaFieldsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FormulaFieldParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(FormulaFieldParameter.FieldName) }.ToList());
            return await _repository.GetModelPagedReponseAsync<FormulaFieldParameter, FormulaFieldModel>(validFilter);
        }
    }
}
