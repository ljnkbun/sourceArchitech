using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class UpdateStatusExportDetailCommand : IRequest<Responses.Response<int>>
    {
        public int Id { get; set; }
        public ItemStatus? Status { get; set; }
    }

    public class UpdateStatusExportDetailCommandHandler : IRequestHandler<UpdateStatusExportDetailCommand, Responses.Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportDetailRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateStatusExportDetailCommandHandler(IMapper mapper
            , IExportDetailRepository repository
            , IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Responses.Response<int>> Handle(UpdateStatusExportDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ExportDetail Not Found.");
            entity.Status = command.Status;
            await _repository.UpdateAsync(entity);

            await _publishEndpoint.Publish(new EventBus.Models.Message.UpdateStatusExportDetailsMessage(new int[] { entity.Id }, _mapper.Map<EventBus.Definations.ItemStatus>(command.Status)), cancellationToken);
            return new Responses.Response<int>(entity.Id);
        }
    }
}
