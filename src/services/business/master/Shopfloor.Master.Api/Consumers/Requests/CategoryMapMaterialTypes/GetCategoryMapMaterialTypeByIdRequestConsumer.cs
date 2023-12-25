using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.CategoryMapMaterialTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCategoryMapMaterialTypeByIdRequestConsumer : IConsumer<GetCategoryMapMaterialTypeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCategoryMapMaterialTypeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCategoryMapMaterialTypeByIdRequest> context)
        {
            Log.Warning($"GetCategoryMapMaterialTypeByIdRequestConsumer: request={context.Message.ToJson()}");

            var accountGroup = await _mediator.Send(new GetCategoryMapMaterialTypeQuery() { Id = context.Message.Id });
            if (accountGroup?.Data == null) await context.RespondAsync(null);
            var response = new GetCategoryMapMaterialTypeByIdResponse
            {
                Id = accountGroup.Data.Id,
                MaterialTypeId = accountGroup.Data.MaterialTypeId,
                CategoryId = accountGroup.Data.CategoryId,
                IsActive = accountGroup.Data.IsActive
            };
            Log.Information($"GetCategoryMapMaterialTypeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}