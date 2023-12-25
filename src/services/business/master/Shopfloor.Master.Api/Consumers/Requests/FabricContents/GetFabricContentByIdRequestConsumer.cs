using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Themes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetFabricContentByIdRequestConsumer : IConsumer<GetFabricContentByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFabricContentByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFabricContentByIdRequest> context)
        {
            Log.Warning($"GetFabricContentByIdRequestConsumer: request={context.Message.ToJson()}");

            var currencies = await _mediator.Send(new GetThemeQuery() { Id = context.Message.Id });
            if (currencies?.Data == null) await context.RespondAsync(null);
            var response = new GetFabricContentByIdResponse
            {
                Id = currencies.Data.Id,
                Code = currencies.Data.Code,
                Name = currencies.Data.Name,
                IsActive = currencies.Data.IsActive
            };
            Log.Information($"GetFabricContentByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}