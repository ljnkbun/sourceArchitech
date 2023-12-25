using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ShipmentTerms;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetShipmentTermByIdRequestConsumer : IConsumer<GetShipmentTermByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetShipmentTermByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetShipmentTermByIdRequest> context)
        {
            Log.Warning($"GetShipmentTermByIdRequestConsumer: request={context.Message.ToJson()}");

            var shipmentTerms = await _mediator.Send(new GetShipmentTermQuery() { Id = context.Message.Id });
            if (shipmentTerms?.Data == null) await context.RespondAsync(null);
            var response = new GetShipmentTermByIdResponse
            {
                Id = shipmentTerms.Data.Id,
                Code = shipmentTerms.Data.Code,
                Name = shipmentTerms.Data.Name,
                IsActive = shipmentTerms.Data.IsActive
            };
            Log.Information($"GetShipmentTermByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}