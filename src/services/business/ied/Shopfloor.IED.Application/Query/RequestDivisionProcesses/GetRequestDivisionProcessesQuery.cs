using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.RequestDivisionProcesses;
using Shopfloor.IED.Application.Parameters.RequestDivisionProcesses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestDivisionProcesses
{
    public class GetRequestDivisionProcessesQuery : IRequest<PagedResponse<IReadOnlyList<RequestDivisionProcessModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? RequestDivisionId { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int? LineNumber { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetRequestDivisionProcesssesQueryHandler : IRequestHandler<GetRequestDivisionProcessesQuery, PagedResponse<IReadOnlyList<RequestDivisionProcessModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestDivisionProcessRepository _repository;
        public GetRequestDivisionProcesssesQueryHandler(IMapper mapper,
            IRequestDivisionProcessRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RequestDivisionProcessModel>>> Handle(GetRequestDivisionProcessesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RequestDivisionProcessParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RequestDivisionProcessParameter, RequestDivisionProcessModel>(validFilter);
        }
    }
}
