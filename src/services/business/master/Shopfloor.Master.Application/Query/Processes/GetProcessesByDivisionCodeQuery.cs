using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Processes;
using Shopfloor.Master.Application.Parameters.Processes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Processes
{
    public class GetProcessesByDivisionCodeQuery : IRequest<PagedResponse<IReadOnlyList<ProcessModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"ProcessesByDivisionCode";
        public TimeSpan? SlidingExpiration { get; set; }
    }

    public class GetProcessesByDivisionCodeQueryHandler : IRequestHandler<GetProcessesByDivisionCodeQuery, PagedResponse<IReadOnlyList<ProcessModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessRepository _repository;

        public GetProcessesByDivisionCodeQueryHandler(IProcessRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IReadOnlyList<ProcessModel>>> Handle(GetProcessesByDivisionCodeQuery query, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ProcessByDivisionIdParameter>(query);
            validFilter.SetSearchProps(new string[]
            {
                nameof(ProcessByDivisionIdParameter.DivisionId),
                nameof(ProcessByDivisionIdParameter.DivisionCode),
            }.ToList());
            return await _repository.GetProcessByDivisionCodePagedResponseAsync<ProcessByDivisionIdParameter, ProcessModel>(
                validFilter, query.DivisionCode);
        }
    }
}