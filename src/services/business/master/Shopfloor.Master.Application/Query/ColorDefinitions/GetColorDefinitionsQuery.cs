using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.ColorDefinitions;
using Shopfloor.Master.Application.Parameters.Certificates;
using Shopfloor.Master.Application.Parameters.ColorDefinitions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ColorDefinitions
{
    public class GetColorDefinitionsQuery : IRequest<PagedResponse<IReadOnlyList<ColorDefinitionModel>>>, ICacheableMediatrQuery
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
        public bool BypassCache { get; set; }
        public string CacheKey => $"ColorDefinitions";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetColorDefinitionsQueryHandler : IRequestHandler<GetColorDefinitionsQuery, PagedResponse<IReadOnlyList<ColorDefinitionModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IColorDefinitionRepository _repository;
        public GetColorDefinitionsQueryHandler(IMapper mapper,
            IColorDefinitionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ColorDefinitionModel>>> Handle(GetColorDefinitionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ColorDefinitionParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ColorDefinitionModel.Code), nameof(ColorDefinitionModel.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ColorDefinitionParameter, ColorDefinitionModel>(validFilter);
        }
    }
}
