using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturings
{
    public class CreateDefectCapturingCommand : IRequest<Response<int>>
    {
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
        public string RootCauseName { get; set; }
        public string PersonInChargeName { get; set; }
        public string CorrectActionName { get; set; }

        public int? TimelineId { get; set; }
    }
    public class CreateDefectCapturingCommandHandler : IRequestHandler<CreateDefectCapturingCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDefectCapturingRepository _repository;
        public CreateDefectCapturingCommandHandler(IMapper mapper,
            IDefectCapturingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDefectCapturingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DefectCapturing>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
