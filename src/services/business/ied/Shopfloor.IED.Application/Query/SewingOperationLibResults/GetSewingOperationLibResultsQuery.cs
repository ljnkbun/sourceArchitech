using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationLibResults;
using Shopfloor.IED.Application.Parameters.SewingOperationLibResults;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingOperationLibResults
{
    public class GetSewingOperationLibResultsQuery : IRequest<PagedResponse<IReadOnlyList<GetSewingOperationLibResultModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? SewingOperationLibId { get; set; }
        public TMUType? TMUType { get; set; }
        public decimal? TMU { get; set; }
        public decimal? BasicMunite { get; set; }
        public decimal? PersonalAllowance { get; set; }
        public decimal? MachineDelay { get; set; }
        public decimal? Total { get; set; }
        public decimal? Contingency { get; set; }
        public decimal? SMV { get; set; }
        public decimal? Cost { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetSewingOperationLibResultsQueryHandler : IRequestHandler<GetSewingOperationLibResultsQuery, PagedResponse<IReadOnlyList<GetSewingOperationLibResultModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingOperationLibResultRepository _repository;
        public GetSewingOperationLibResultsQueryHandler(IMapper mapper,
            ISewingOperationLibResultRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<GetSewingOperationLibResultModel>>> Handle(GetSewingOperationLibResultsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingOperationLibResultParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingOperationLibResultParameter, GetSewingOperationLibResultModel>(validFilter);
        }
    }
}
