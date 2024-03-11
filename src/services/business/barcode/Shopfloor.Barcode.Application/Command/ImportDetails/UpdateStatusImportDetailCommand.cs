using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportDetails
{
    public class UpdateStatusImportDetailCommand : IRequest<Responses.Response<int>>
    {
        public int Id { get; set; }
        public ItemStatus? Status { get; set; }
    }

    public class UpdateStatusImportDetailCommandHandler : IRequestHandler<UpdateStatusImportDetailCommand, Responses.Response<int>>
    {
        private readonly IImportDetailRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public UpdateStatusImportDetailCommandHandler(IMapper mapper
            , IImportDetailRepository repository
            , IPublishEndpoint publishEndpoint
            )
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        public async Task<Responses.Response<int>> Handle(UpdateStatusImportDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"ImportDetail Not Found.");
            entity.Status = command.Status;
            await _repository.UpdateAsync(entity);

            await _publishEndpoint.Publish(new EventBus.Models.Message.UpdateStatusImportDetailsMessage(new int[] { entity.Id }, _mapper.Map<EventBus.Definations.ItemStatus>(command.Status)), cancellationToken);

            return new Responses.Response<int>(entity.Id);
        }
    }
}
