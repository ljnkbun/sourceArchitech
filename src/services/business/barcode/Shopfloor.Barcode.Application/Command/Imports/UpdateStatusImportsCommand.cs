using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Imports
{
    public class UpdateStatusImportsCommand : IRequest<Responses.Response<bool>>
    {
        public string Ids { get; set; }
        public ImportStatus? Status { get; set; }
    }

    public class UpdateStatusImportsCommandHandler : IRequestHandler<UpdateStatusImportsCommand, Responses.Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IImportRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateStatusImportsCommandHandler(IMapper mapper
            , IImportRepository repository
            , IPublishEndpoint publishEndpoint
            )
        {
            _mapper = mapper;
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Responses.Response<bool>> Handle(UpdateStatusImportsCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.Ids)) return new($"Import Not Found.");

            var ids = command.Ids.Split(",").Select(x => int.Parse(x));
            var entities = await _repository.GetByIdsAsync(ids.ToArray());
            if (entities == null || !entities.Any()) return new($"Import Not Found.");

            foreach (var entity in entities)
            {
                entity.Status = command.Status;
            }

            await _repository.UpdateRangeAsync(entities.ToList());

            await _publishEndpoint.Publish(new EventBus.Models.Message.UpdateStatusImportsMessage(ids.ToArray(), _mapper.Map<EventBus.Definations.NoteStatus>(command.Status)), cancellationToken);

            return new Responses.Response<bool>(true);
        }
    }
}
