using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetWfxPOArticleRequestConsumer : IConsumer<GetWfxPOArticleRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetWfxPOArticleRequestConsumer(IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxPOArticleRequest> context)
        {
            Log.Warning($"GetImportPOArticleRequestConsumer: request={context.Message.ToJson()}");

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
            Log.Information($"GetImportPOArticleRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}