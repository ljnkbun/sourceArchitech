using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class UpdateExportDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public ItemStatus? Status { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
        public string UOM { get; set; }

        public decimal? Yard { get; set; }
        public decimal? Meter { get; set; }
        public decimal? Unit { get; set; }
        public string Note { get; set; }
    }

    public class UpdateExportDetailEntityCommandHandler : IRequestHandler<UpdateExportDetailCommand, Response<int>>
    {
        private readonly IExportDetailRepository _repository;

        public UpdateExportDetailEntityCommandHandler(IExportDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateExportDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id) ?? throw new ApiException($"ExportDetail Not Found.");
            entity.Status = command.Status;
            entity.UOM = command.UOM;
            entity.Shade = command.Shade;
            entity.OC = command.OC;
            entity.LotNo = command.LotNo;
            entity.Yard = command.Yard;
            entity.Meter = command.Meter;
            entity.Unit = command.Unit;
            entity.Note = command.Note;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
