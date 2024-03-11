using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingRappoMarks;
using Shopfloor.IED.Application.Parameters.WeavingRappoMarks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRappoMarks
{
    public class GetWeavingRappoMarksQuery : IRequest<PagedResponse<IReadOnlyList<WeavingRappoMarkModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingRappoId { get; set; }
        public int? ColumnNo { get; set; }
        public int? PatternIndex { get; set; }
        public bool? Type { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetWeavingRappoMarksQueryHandler : IRequestHandler<GetWeavingRappoMarksQuery, PagedResponse<IReadOnlyList<WeavingRappoMarkModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRappoMarkRepository _repository;
        public GetWeavingRappoMarksQueryHandler(IMapper mapper,
            IWeavingRappoMarkRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingRappoMarkModel>>> Handle(GetWeavingRappoMarksQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingRappoMarkParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingRappoMarkParameter, WeavingRappoMarkModel>(validFilter);
        }
    }
}
