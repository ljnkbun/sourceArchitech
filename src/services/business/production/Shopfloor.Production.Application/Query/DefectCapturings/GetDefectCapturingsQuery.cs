using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.DefectCapturings;
using Shopfloor.Production.Application.Parameters.DefectCapturings;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.DefectCapturings
{
    public class GetDefectCapturingsQuery : IRequest<PagedResponse<IReadOnlyList<DefectCapturingModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critical { get; set; }
        public int? ParentId { get; set; }
        public string RootCauseIds { get; set; }
        public string PersonInChargeIds { get; set; }
        public string CorrectActionIds { get; set; }
        public bool? IsLongError { get; set; }
        public decimal? LongErrorFrom { get; set; }
        public decimal? LongErrorTo { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorName { get; set; }

        public int? TimelineId { get; set; }


        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetDefectCapturingsQueryHandler : IRequestHandler<GetDefectCapturingsQuery, PagedResponse<IReadOnlyList<DefectCapturingModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDefectCapturingRepository _repository;
        public GetDefectCapturingsQueryHandler(IMapper mapper,
            IDefectCapturingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DefectCapturingModel>>> Handle(GetDefectCapturingsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DefectCapturingParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DefectCapturingParameter, DefectCapturingModel>(validFilter);
        }
    }
}
