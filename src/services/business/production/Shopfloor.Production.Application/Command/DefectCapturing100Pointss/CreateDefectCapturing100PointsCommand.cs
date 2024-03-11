using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturing100Pointss
{
    public class CreateDefectCapturing100PointsCommand : IRequest<Response<int>>
    {
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
    }
    public class CreateDefectCapturing100PointsCommandHandler : IRequestHandler<CreateDefectCapturing100PointsCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDefectCapturing100PointsRepository _repository;
        public CreateDefectCapturing100PointsCommandHandler(IMapper mapper,
            IDefectCapturing100PointsRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDefectCapturing100PointsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DefectCapturing100Points>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
