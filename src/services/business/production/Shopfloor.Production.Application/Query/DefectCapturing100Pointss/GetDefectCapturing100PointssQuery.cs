using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.DefectCapturing100Pointss;
using Shopfloor.Production.Application.Parameters.DefectCapturing100Pointss;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.DefectCapturing100Pointss
{
    public class GetDefectCapturing100PointssQuery : IRequest<PagedResponse<IReadOnlyList<DefectCapturing100PointsModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }

        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critial { get; set; }
        public string Remark { get; set; }

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
    public class GetDefectCapturing100PointssQueryHandler : IRequestHandler<GetDefectCapturing100PointssQuery, PagedResponse<IReadOnlyList<DefectCapturing100PointsModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDefectCapturing100PointsRepository _repository;
        public GetDefectCapturing100PointssQueryHandler(IMapper mapper,
            IDefectCapturing100PointsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DefectCapturing100PointsModel>>> Handle(GetDefectCapturing100PointssQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DefectCapturing100PointsParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DefectCapturing100PointsParameter, DefectCapturing100PointsModel>(validFilter);
        }
    }
}
