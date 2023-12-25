using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SupplierTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSupplierTypeByIdRequestConsumer : IConsumer<GetSupplierTypeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSupplierTypeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSupplierTypeByIdRequest> context)
        {
            Log.Warning($"GetSupplierTypeByIdRequestConsumer: request={context.Message.ToJson()}");

            var supplierTypes = await _mediator.Send(new GetSupplierTypeQuery() { Id = context.Message.Id });
            if (supplierTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetSupplierTypeByIdResponse
            {
                Id = supplierTypes.Data.Id,
                Code = supplierTypes.Data.Code,
                Name = supplierTypes.Data.Name,
                IsActive = supplierTypes.Data.IsActive
            };
            Log.Information($"GetSupplierTypeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}