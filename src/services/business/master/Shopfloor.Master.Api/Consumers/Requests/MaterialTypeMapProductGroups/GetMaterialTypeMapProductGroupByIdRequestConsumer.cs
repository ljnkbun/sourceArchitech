using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.MaterialTypeMapProductGroups;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetMaterialTypeMapProductGroupByIdRequestConsumer : IConsumer<GetMaterialTypeMapProductGroupByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMaterialTypeMapProductGroupByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMaterialTypeMapProductGroupByIdRequest> context)
        {
            Log.Warning($"GetMaterialTypeMapProductGroupByIdRequestConsumer: request={context.Message.ToJson()}");

            var accountGroup = await _mediator.Send(new GetMaterialTypeMapProductGroupQuery() { Id = context.Message.Id });
            if (accountGroup?.Data == null) await context.RespondAsync(null);
            var response = new GetMaterialTypeMapProductGroupByIdResponse
            {
                Id = accountGroup.Data.Id,
                ProductGroupId = accountGroup.Data.ProductGroupId,
                MaterialTypeId = accountGroup.Data.MaterialTypeId,
                IsActive = accountGroup.Data.IsActive
            };
            Log.Information($"GetMaterialTypeMapProductGroupByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}