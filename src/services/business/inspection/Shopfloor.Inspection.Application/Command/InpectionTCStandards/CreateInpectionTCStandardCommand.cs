using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.Attachments;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.InpectionTCStandards
{
    public class CreateInpectionTCStandardCommand : IRequest<Response<int>>
    {
        public int QCRequestArticleId { get; set; }
        public string StockMovementNo { get; set; }
        public string Grade { get; set; }
        public bool Result { get; set; }
        public int PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public bool IsCreatedFromProduction { get; set; }
        public DateTime InspectionDate { get; set; }
        public ICollection<CreateAttachmentCommand> Attachments { get; set; }
        public ICollection<CreateInspectionDefectCapturingTCStandardCommand> InspectionDefectCapturingTCStandards { get; set; }
    }
    public class CreateInpectionTCStandardCommandHandler : IRequestHandler<CreateInpectionTCStandardCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IInpectionTCStandardRepository _repository;
        public CreateInpectionTCStandardCommandHandler(IMapper mapper,
            IInpectionTCStandardRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInpectionTCStandardCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InpectionTCStandard>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
