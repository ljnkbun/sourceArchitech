using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.Formulas;
using Shopfloor.IED.Application.Parameters.Formulas;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Formulas
{
    public class GetFormulasQuery : IRequest<PagedResponse<IReadOnlyList<FormulaModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Expression { get; set; }
        public string ProcessCode { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Formulas";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFormulasQueryHandler : IRequestHandler<GetFormulasQuery, PagedResponse<IReadOnlyList<FormulaModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFormulaRepository _repository;
        public GetFormulasQueryHandler(IMapper mapper,
            IFormulaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FormulaModel>>> Handle(GetFormulasQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FormulaParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(FormulaParameter.Code), nameof(FormulaParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<FormulaParameter, FormulaModel>(validFilter);
        }
    }
}
