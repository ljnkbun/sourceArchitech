using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class UpdateExportDetailsCommand : IRequest<Response<bool>>
    {
        public ICollection<UpdateExportDetailCommand> ExportDetails { get; set; }
    }

    public class UpdateExportDetailEntitiesCommandHandler : IRequestHandler<UpdateExportDetailsCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IExportDetailRepository _repository;

        public UpdateExportDetailEntitiesCommandHandler(IMapper mapper
            , IExportDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(UpdateExportDetailsCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdsAsync(command.ExportDetails.Select(x => x.Id).ToArray());
            if (entities == null || !entities.Any()) return new($"ExportDetail Not Found.");
            var updateEntities = _mapper.Map<List<ExportDetail>>(command.ExportDetails);
            foreach (var entity in entities)
            {
                var updateEntity = updateEntities.Find(x => x.Id == entity.Id);
                if (updateEntity == null) continue;

                entity.Status = updateEntity.Status;
                entity.UOM = updateEntity.UOM;
                entity.Note = updateEntity.Note;
            }

            await _repository.UpdateRangeAsync(entities.ToList());
            return new Response<bool>(true);
        }
    }
}
