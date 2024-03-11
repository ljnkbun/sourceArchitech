using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.Inpection4PointSyss
{
    public class UpdateInpection4PointSysCommand : IRequest<Response<int>>
    {
        public int? QCRequestArticleId { get; set; }
        public string StockMovementNo { get; set; }
        public decimal CaptureMeter { get; set; }
        public decimal ActualWeight { get; set; }
        public int TotalDefect { get; set; }
        public int TotalContDefect { get; set; }
        public int TotalPoint { get; set; }
        public int PointSquareMeter { get; set; }
        public int? WarpDensity { get; set; }
        public int? WeftDensity { get; set; }
        public int PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public int? AttachmentId { get; set; }
        public bool SystemResult { get; set; }
        public bool UserResult { get; set; }
        public string Grade { get; set; }
        public decimal? WeightGM2 { get; set; }
        public int Id { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool IsCreatedFromProduction { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateInspectionDefectCapturing4PointSysCommand> InspectionDefectCapturing4PointSyss { get; set; }
    }
    public class UpdateInpection4PointSysCommandHandler : IRequestHandler<UpdateInpection4PointSysCommand, Response<int>>
    {
        private readonly IInpection4PointSysRepository _repository;
        private readonly IMapper _mapper;
        public UpdateInpection4PointSysCommandHandler(IMapper mapper, IInpection4PointSysRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateInpection4PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetInpection4PointSysWithDetaiḷ(command.Id);

            if (entity == null) return new($"Inpection4PointSys Not Found.");
            var dbDefectCapturing4PointSys = entity.InspectionDefectCapturing4PointSyss;
            var newDefectCapturing4PointSys = command.InspectionDefectCapturing4PointSyss;
            var dbDefectError4PointSys = entity.InspectionDefectCapturing4PointSyss.SelectMany(x => x.InspectionDefectError4PointSyss);
            var newDefectError4PointSys = command.InspectionDefectCapturing4PointSyss.SelectMany(x => x.InspectionDefectError4PointSyss);
            entity.IsActive = command.IsActive;
            entity.QCRequestArticleId = command.QCRequestArticleId;
            entity.StockMovementNo = command.StockMovementNo;
            entity.CaptureMeter = command.CaptureMeter;
            entity.ActualWeight = command.ActualWeight;
            entity.TotalDefect = command.TotalDefect;
            entity.TotalContDefect = command.TotalContDefect;
            entity.TotalPoint = command.TotalPoint;
            entity.PointSquareMeter = command.PointSquareMeter;
            entity.WarpDensity = command.WarpDensity;
            entity.WeftDensity = command.WeftDensity;
            entity.PersonInChargeId = command.PersonInChargeId;
            entity.Remark = command.Remark;
            entity.SystemResult = command.SystemResult;
            entity.UserResult = command.UserResult;
            entity.Grade = command.Grade;
            entity.WeightGM2 = command.WeightGM2;
            entity.IsCreatedFromProduction = command.IsCreatedFromProduction;
            entity.InspectionDate = command.InspectionDate;
            entity.InspectionDefectCapturing4PointSyss = null;
            var dbDefectCapturing4PointSysModifieds = dbDefectCapturing4PointSys.Where(x => newDefectCapturing4PointSys.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateInspectionDefectCapturing4PointSysCommand, InspectionDefectCapturing4PointSys>(newDefectCapturing4PointSys.First(c => c.Id == x.Id), x));
            var dbDefectError4PointSysModifieds = dbDefectError4PointSys.Where(x => newDefectError4PointSys.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateInspectionDefectError4PointSysCommand, InspectionDefectError4PointSys>(newDefectError4PointSys.First(c => c.Id == x.Id), x));
            await _repository.UpdateInspection4PointSysAsync(entity, dbDefectCapturing4PointSysModifieds, dbDefectError4PointSysModifieds);
            return new Response<int>(entity.Id);
        }
    }
}
