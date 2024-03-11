using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class UpdateStatusExportDetailsCommand : IRequest<Responses.Response<bool>>
    {
        public string Ids { get; set; }
        public ItemStatus? Status { get; set; }
    }

    public class UpdateStatusExportDetailsCommandHandler : IRequestHandler<UpdateStatusExportDetailsCommand, Responses.Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IExportDetailRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateStatusExportDetailsCommandHandler(IMapper mapper
            , IExportDetailRepository repository
            , IPublishEndpoint publishEndpoint
            )
        {
            _mapper = mapper;
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Responses.Response<bool>> Handle(UpdateStatusExportDetailsCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.Ids)) return new($"ExportDetail Not Found.");

            var ids = command.Ids.Split(",").Select(x => int.Parse(x));
            var entities = await _repository.GetByIdsAsync(ids.ToArray());
            if (entities == null || !entities.Any()) return new($"ExportDetail Not Found.");

            foreach (var entity in entities)
            {
                entity.Status = command.Status;
            }

            await _repository.UpdateRangeAsync(entities.ToList());

            await _publishEndpoint.Publish(new EventBus.Models.Message.UpdateStatusExportDetailsMessage(ids.ToArray(), _mapper.Map<EventBus.Definations.ItemStatus>(command.Status)), cancellationToken);

            return new Responses.Response<bool>(true);
        }
    }
}
