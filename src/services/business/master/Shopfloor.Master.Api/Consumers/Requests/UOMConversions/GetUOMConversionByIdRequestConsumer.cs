using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.UOMConversions;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetUOMConversionByIdRequestConsumer : IConsumer<GetUOMConversionByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetUOMConversionByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetUOMConversionByIdRequest> context)
        {
            Log.Warning($"GetUOMConversionByIdRequestConsumer: request={context.Message.ToJson()}");

            var uomConversions = await _mediator.Send(new GetUOMConversionQuery() { Id = context.Message.Id });
            if (uomConversions?.Data == null) await context.RespondAsync(null);
            var response = new GetUOMConversionByIdResponse
            {
                Id = uomConversions.Data.Id,
                FromUOMId = uomConversions.Data.FromUOMId,
                ToUOMId = uomConversions.Data.ToUOMId,
                Value = uomConversions.Data.Value,
                IsActive = uomConversions.Data.IsActive
            };
            Log.Information($"GetUOMConversionByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}