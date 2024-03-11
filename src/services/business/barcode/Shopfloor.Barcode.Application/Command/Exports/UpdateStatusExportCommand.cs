using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Exports
{
    public class UpdateStatusExportCommand : IRequest<Responses.Response<int>>
    {
        public int Id { get; set; }
        public ExportStatus? Status { get; set; }
    }

    public class UpdateStatusExportCommandHandler : IRequestHandler<UpdateStatusExportCommand, Responses.Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateStatusExportCommandHandler(IMapper mapper,
            IExportRepository repository
            , IPublishEndpoint publishEndpoint
            )
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        public async Task<Responses.Response<int>> Handle(UpdateStatusExportCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetExportByIdAsync(command.Id);
            if (entity == null) return new($"ExportEntity Not Found.");
            entity.Status = command.Status;
            await _repository.UpdateAsync(entity);

            await _publishEndpoint.Publish(new EventBus.Models.Message.UpdateStatusExportsMessage(new int[] { entity.Id }, _mapper.Map<EventBus.Definations.NoteStatus>(command.Status)), cancellationToken);
            return new Responses.Response<int>(entity.Id);
        }
    }
}
