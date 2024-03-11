using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Ambassador.Application.Query.Wfxs;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Dtos;
using Shopfloor.EventBus.Models.Requests.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Api.Consumers.Wfxs
{
    public class GetWfxPorRequestConsumer : IConsumer<GetWfxPorRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetWfxPorRequestConsumer(IMediator mediator
            )
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxPorRequest> context)
        {
            try
            {
                Log.Warning($"GetWfxPorRequestConsumer: request={context.Message.ToJson()}");

                var wfxPor = await _mediator.Send(new GetWfxPorDataQuery()
                {
                    Category = context.Message.Category,
                    OcNo = context.Message.OCNO,
                    GETLastDays = context.Message.GETLastDays,
                });
                var response = new GetPorSyncResponse
                {
                    Data = wfxPor.Data.ToList(),
                };
                Log.Information($"GetWfxPorRequestConsumer: response={response}");

                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error($"GetWfxPorRequestConsumer: {ex}");
            }
        }
    }
}
