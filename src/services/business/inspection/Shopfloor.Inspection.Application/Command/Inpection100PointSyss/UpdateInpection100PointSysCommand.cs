using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.Inpection100PointSyss
{
    public class UpdateInpection100PointSysCommand : IRequest<Response<int>>
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
        public bool SystemResult { get; set; }
        public bool UserResult { get; set; }
        public string Grade { get; set; }
        public decimal? WeightGM2 { get; set; }
        public int Id { get; set; }
        public bool IsCreatedFromProduction { get; set; }
        public bool IsActive { set; get; }
        public DateTime InspectionDate { get; set; }
        public ICollection<UpdateInspectionDefectCapturing100PointSysCommand> InspectionDefectCapturing100PointSyss { get; set; }
    }
    public class UpdateInpection100PointSysCommandHandler : IRequestHandler<UpdateInpection100PointSysCommand, Response<int>>
    {
        private readonly IInpection100PointSysRepository _repository;
        private readonly IMapper _mapper;
        public UpdateInpection100PointSysCommandHandler(IMapper mapper, IInpection100PointSysRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateInpection100PointSysCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Inpection100PointSys Not Found.");
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
            entity.InspectionDefectCapturing100PointSyss = null;
            var dbDefectCapturing100PointSys = entity.InspectionDefectCapturing100PointSyss;
            var newDefectCapturing100PointSys = command.InspectionDefectCapturing100PointSyss;
            var dbDefectError100PointSys = entity.InspectionDefectCapturing100PointSyss.SelectMany(x => x.InspectionDefectError100PointSyss);
            var newDefectError100PointSys = command.InspectionDefectCapturing100PointSyss.SelectMany(x => x.InspectionDefectError100PointSyss);
            var dbDefectCapturing100PointSysModifieds = dbDefectCapturing100PointSys.Where(x => newDefectCapturing100PointSys.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateInspectionDefectCapturing100PointSysCommand, InspectionDefectCapturing100PointSys>(newDefectCapturing100PointSys.First(c => c.Id == x.Id), x));
            var dbDefectError100PointSysModifieds = dbDefectError100PointSys.Where(x => newDefectError100PointSys.Any(c => c.Id == x.Id))
                .Select(x => _mapper.Map<UpdateInspectionDefectError100PointSysCommand, InspectionDefectError100PointSys>(newDefectError100PointSys.First(c => c.Id == x.Id), x));
            await _repository.UpdateInspection100PointSysAsync(entity, dbDefectCapturing100PointSys, dbDefectError100PointSys);
            return new Response<int>(entity.Id);
        }
    }
}
