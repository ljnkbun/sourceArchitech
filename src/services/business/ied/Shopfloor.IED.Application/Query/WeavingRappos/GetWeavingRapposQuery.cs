using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingRappos;
using Shopfloor.IED.Application.Parameters.WeavingRappos;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRappos
{
    public class GetWeavingRapposQuery : IRequest<PagedResponse<IReadOnlyList<WeavingRappoModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingIEDId { get; set; }
        public int? Line { get; set; }
        public int? WarpPerMarginDentSplit { get; set; }
        public int? WarpPerContentDentSplit { get; set; }
        public int? TotalRappo { get; set; }
        public int? AdditionYarn { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public string DrawingComment { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetWeavingRapposQueryHandler : IRequestHandler<GetWeavingRapposQuery, PagedResponse<IReadOnlyList<WeavingRappoModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRappoRepository _repository;
        public GetWeavingRapposQueryHandler(IMapper mapper,
            IWeavingRappoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingRappoModel>>> Handle(GetWeavingRapposQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingRappoParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingRappoParameter, WeavingRappoModel>(validFilter);
        }
    }
}
