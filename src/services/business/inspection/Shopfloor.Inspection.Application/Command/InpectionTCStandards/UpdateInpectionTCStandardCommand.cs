using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.InpectionTCStandards
{
    public class UpdateInpectionTCStandardCommand : IRequest<Response<int>>
    {
        public int QCRequestArticleId { get; set; }
        public string StockMovementNo { get; set; }
        public string Grade { get; set; }
        public bool Result { get; set; }
        public int PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public int Id { get; set; }
        public bool IsCreatedFromProduction { get; set; }
        public bool IsActive { set; get; }
        public DateTime InspectionDate { get; set; }
        public ICollection<UpdateInspectionDefectCapturingTCStandardCommand> InspectionDefectCapturingTCStandards { get; set; }
    }
    public class UpdateInpectionTCStandardCommandHandler : IRequestHandler<UpdateInpectionTCStandardCommand, Response<int>>
    {
        private readonly IInpectionTCStandardRepository _repository;
        private readonly IMapper _mapper;
        public UpdateInpectionTCStandardCommandHandler(IMapper mapper, IInpectionTCStandardRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateInpectionTCStandardCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"InpectionTCStandard Not Found.");
            entity.IsActive = command.IsActive;
            entity.QCRequestArticleId = command.QCRequestArticleId;
            entity.StockMovementNo = command.StockMovementNo;
            entity.Grade = command.Grade;
            entity.Result = command.Result;
            entity.PersonInChargeId = command.PersonInChargeId;
            entity.Remark = command.Remark;
            entity.InspectionDate = command.InspectionDate;
            entity.IsCreatedFromProduction = command.IsCreatedFromProduction;
            entity.InspectionDefectCapturingTCStandards = null;
            var dbDefectCapturingTCStandard = entity.InspectionDefectCapturingTCStandards;
            var newDefectCapturingTCStandard = command.InspectionDefectCapturingTCStandards;
            var dbDefectCapturingTCStandardModifieds = dbDefectCapturingTCStandard.Where(x => newDefectCapturingTCStandard.Any(c => c.Id == x.Id))
               .Select(x => _mapper.Map<UpdateInspectionDefectCapturingTCStandardCommand, InspectionDefectCapturingTCStandard>(newDefectCapturingTCStandard.First(c => c.Id == x.Id), x));
            await _repository.UpdateInspectionTCStandardAsync(entity, dbDefectCapturingTCStandardModifieds);
            return new Response<int>(entity.Id);
        }
    }
}
