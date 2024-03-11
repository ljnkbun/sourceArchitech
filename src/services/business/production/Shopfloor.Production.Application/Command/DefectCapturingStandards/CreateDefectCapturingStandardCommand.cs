using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturingStandards
{
    public class CreateDefectCapturingStandardCommand : IRequest<Response<int>>
    {
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int Defect { get; set; }
        public int? AttachmentId { get; set; }
        public string Remark { get; set; }
        public string RootCauseIds { get; set; }
        public string CorrectiveActionIds { get; set; }
        public int? TimelineId { get; set; }
        public string PersonInChargeIds { get; set; }
    }
    public class CreateDefectCapturingStandardCommandHandler : IRequestHandler<CreateDefectCapturingStandardCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDefectCapturingStandardRepository _repository;
        public CreateDefectCapturingStandardCommandHandler(IMapper mapper,
            IDefectCapturingStandardRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDefectCapturingStandardCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DefectCapturingStandard>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
