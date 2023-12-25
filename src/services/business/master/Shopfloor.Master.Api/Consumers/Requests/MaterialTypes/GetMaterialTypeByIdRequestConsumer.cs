using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.MaterialTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetMaterialTypeByIdRequestConsumer : IConsumer<GetMaterialTypeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMaterialTypeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMaterialTypeByIdRequest> context)
        {
            Log.Warning($"GetMaterialTypeByIdRequestConsumer: request={context.Message.ToJson()}");

            var materialTypes = await _mediator.Send(new GetMaterialTypeQuery() { Id = context.Message.Id });
            if (materialTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetMaterialTypeByIdResponse
            {
                Id = materialTypes.Data.Id,
                Code = materialTypes.Data.Code,
                Name = materialTypes.Data.Name,
                IsActive = materialTypes.Data.IsActive
            };
            Log.Information($"GetMaterialTypeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}