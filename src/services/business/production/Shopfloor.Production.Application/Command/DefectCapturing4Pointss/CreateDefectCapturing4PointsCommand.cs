using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturing4Pointss
{
    public class CreateDefectCapturing4PointsCommand : IRequest<Response<int>>
    {
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
        public string RootCauseName { get; set; }
        public string PersonInChargeName { get; set; }
        public string CorrectActionName { get; set; }

        public int? TimelineId { get; set; }
    }
    public class CreateDefectCapturing4PointsCommandHandler : IRequestHandler<CreateDefectCapturing4PointsCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDefectCapturing4PointsRepository _repository;
        public CreateDefectCapturing4PointsCommandHandler(IMapper mapper,
            IDefectCapturing4PointsRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDefectCapturing4PointsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DefectCapturing4Points>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
