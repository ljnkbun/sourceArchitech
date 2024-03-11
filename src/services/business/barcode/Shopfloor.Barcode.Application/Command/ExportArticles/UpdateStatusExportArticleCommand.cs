using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportArticles
{
    public class UpdateStatusExportArticleCommand : IRequest<Responses.Response<int>>
    {
        public int Id { get; set; }
        public ItemStatus? Status { get; set; }
    }

    public class UpdateStatusExportArticleCommandHandler : IRequestHandler<UpdateStatusExportArticleCommand, Responses.Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportArticleRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateStatusExportArticleCommandHandler(IMapper mapper
            , IExportArticleRepository repository
            , IPublishEndpoint publishEndpoint
            )
        {
            _mapper = mapper;
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Responses.Response<int>> Handle(UpdateStatusExportArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetExportArticleByIdAsync(command.Id);
            if (entity == null) return new($"ExportArticleEntity Not Found.");
            entity.Status = command.Status;
            await _repository.UpdateAsync(entity);

            await _publishEndpoint.Publish(new EventBus.Models.Message.UpdateStatusExportArticlesMessage(new int[] { entity.Id }, _mapper.Map<EventBus.Definations.ItemStatus>(command.Status)), cancellationToken);

            return new Responses.Response<int>(entity.Id);
        }
    }
}
