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
    public class GetWfxArticleRequestConsumer : IConsumer<GetWfxArticleRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetWfxArticleRequestConsumer(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxArticleRequest> context)
        {
            Log.Warning($"GetArticleRequestConsumer: request={context.Message.ToJson()}");

            var article = await _mediator.Send(new GetWfxArticleQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                SearchDics = context.Message.SearchDics,
            });
            var response = new GetWfxArticleResponse
            {
                Data = _mapper.Map<List<WfxArticleDto>>(article.Data)
            };
            Log.Information($"GetArticleRequestConsumer: response={response.ToJson()}");
            await context.RespondAsync(response);
        }
    }
}