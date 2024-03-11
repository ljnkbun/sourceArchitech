using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.DefectCapturingStandards;
using Shopfloor.Production.Application.Parameters.DefectCapturingStandards;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.DefectCapturingStandards
{
    public class GetDefectCapturingStandardsQuery : IRequest<PagedResponse<IReadOnlyList<DefectCapturingStandardModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int Defect { get; set; }
        public int? AttachmentId { get; set; }
        public string Remark { get; set; }
        public string RootCauseIds { get; set; }
        public string CorrectiveActionIds { get; set; }
        public int? TimelineId { get; set; }
        public string PersonInChargeIds { get; set; }


        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetDefectCapturingStandardsQueryHandler : IRequestHandler<GetDefectCapturingStandardsQuery, PagedResponse<IReadOnlyList<DefectCapturingStandardModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDefectCapturingStandardRepository _repository;
        public GetDefectCapturingStandardsQueryHandler(IMapper mapper,
            IDefectCapturingStandardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DefectCapturingStandardModel>>> Handle(GetDefectCapturingStandardsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DefectCapturingStandardParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DefectCapturingStandardParameter, DefectCapturingStandardModel>(validFilter);
        }
    }
}
