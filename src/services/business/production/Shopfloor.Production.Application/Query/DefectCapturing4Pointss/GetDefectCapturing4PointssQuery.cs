using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Application.Models.DefectCapturing4Pointss;
using Shopfloor.Production.Application.Parameters.DefectCapturing4Pointss;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.DefectCapturing4Pointss
{
    public class GetDefectCapturing4PointssQuery : IRequest<PagedResponse<IReadOnlyList<DefectCapturing4PointsModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }

        public int? DefectQtyOne { get; set; }
        public int? DefectQtyTwo { get; set; }
        public int? DefectQtyThree { get; set; }
        public int? DefectQtyFour { get; set; }
        public int? MinorOne { get; set; }
        public int? MinorTwo { get; set; }
        public int? MinorThree { get; set; }
        public int? MinorFour { get; set; }
        public int? MajorOne { get; set; }
        public int? MajorTwo { get; set; }
        public int? MajorThree { get; set; }
        public int? MajorFour { get; set; }
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
    public class GetDefectCapturing4PointssQueryHandler : IRequestHandler<GetDefectCapturing4PointssQuery, PagedResponse<IReadOnlyList<DefectCapturing4PointsModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDefectCapturing4PointsRepository _repository;
        public GetDefectCapturing4PointssQueryHandler(IMapper mapper,
            IDefectCapturing4PointsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DefectCapturing4PointsModel>>> Handle(GetDefectCapturing4PointssQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DefectCapturing4PointsParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DefectCapturing4PointsParameter, DefectCapturing4PointsModel>(validFilter);
        }
    }
}
