using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Ambassador.Application.Query.Wfxs;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Ambassadors.Wfxs;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Api.Consumers.Wfxs
{
    public class GetWfxWebSharedServiceConsumer : IConsumer<GetWfxWebSharedRequest>
    {
        #region Initialization
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetWfxWebSharedServiceConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxWebSharedRequest> context)
        {
            try
            {
                Log.Warning($"GetWfxWebSharedServiceConsumer: request={context.Message.ToJson()}");

                var wfxWebShared = await _mediator.Send(new GetWfxWebSharedDataQuery()
                {
                    Category = context.Message.Category,
                });

                var response = new GetWfxWebSharedResponse
                {
                    Data = _mapper.Map<List<WfxWebSharedDto>>(wfxWebShared.Data),
                };
                Log.Information($"GetWfxWebSharedServiceConsumer: response={response}");

                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error($"GetWfxWebSharedServiceConsumer: {ex}");
            }
        }
    }
}
