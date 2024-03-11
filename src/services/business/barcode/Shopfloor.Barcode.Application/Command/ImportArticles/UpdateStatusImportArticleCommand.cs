using AutoMapper;
using MassTransit;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Responses = Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportArticles
{
    public class UpdateStatusImportArticleCommand : IRequest<Responses.Response<int>>
    {
        public int Id { get; set; }
        public ItemStatus? Status { get; set; }
    }

    public class UpdateStatusImportArticleCommandHandler : IRequestHandler<UpdateStatusImportArticleCommand, Responses.Response<int>>
    {
        private readonly IImportArticleRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateStatusImportArticleCommandHandler(IImportArticleRepository repository
            , IMapper mapper
            , IPublishEndpoint publishEndpoint
            )
        {
            _repository = repository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Responses.Response<int>> Handle(UpdateStatusImportArticleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetImportArticleByIdAsync(command.Id);
            if (entity == null) return new($"ImportArticle Not Found.(Id:{command.Id}).");
            entity.Status = command.Status;

            await _repository.UpdateAsync(entity);

            await _publishEndpoint.Publish(new EventBus.Models.Message.UpdateStatusImportArticlesMessage(new int[] { entity.Id }, _mapper.Map<EventBus.Definations.ItemStatus>(command.Status)), cancellationToken);
            return new Responses.Response<int>(entity.Id);
        }
    }
}
