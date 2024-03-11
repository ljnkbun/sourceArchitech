using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.Ambassador.Infrastructure.Services;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Api.Consumers.Requests
{
    public class GetWfxPOArticleRequestConsumer : IConsumer<GetWfxPOArticleRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<GetWfxPOArticleRequestConsumer> _logger;

        public GetWfxPOArticleRequestConsumer(IMediator mediator,
            IMapper mapper, ILogger<GetWfxPOArticleRequestConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxPOArticleRequest> context)
        {
            _logger.LogInformation($"GetImportPOArticleRequestConsumer: request={context.Message.ToJson()}");

            var importPOArticle = await _mediator.Send(new GetWfxPOArticleQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                SearchDics = context.Message.SearchDics,
            });
            var response = new GetWfxPOArticleResponse
            {
                Data = _mapper.Map<List<WfxPOArticleDto>>(importPOArticle.Data),
            };
            _logger.LogInformation($"GetImportPOArticleRequestConsumer: response={response.ToJson()}");
            await context.RespondAsync(response);
        }
    }
}