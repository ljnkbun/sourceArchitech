using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Suppliers;
using Shopfloor.EventBus.Models.Responses.Masters.Suppliers;
using Shopfloor.Master.Application.Query.Suppliers;

namespace Shopfloor.Master.Api.Consumers.Requests.Suppliers
{
    public class GetSupplierByIdRequestConsumer : IConsumer<GetSupplierByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSupplierByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSupplierByIdRequest> context)
        {
            Log.Warning($"GetSupplierByIdRequestConsumer: request={context.Message.ToJson()}");

            var suppliers = await _mediator.Send(new GetSupplierQuery() { Id = context.Message.Id });
            if (suppliers?.Data == null) await context.RespondAsync(null);
            var response = new GetSupplierByIdResponse
            {
                Id = suppliers.Data.Id,
                WFXSupplierId = suppliers.Data.WFXSupplierId,
                Name = suppliers.Data.Name,
                IsActive = suppliers.Data.IsActive
            };
            Log.Information($"GetSupplierByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}