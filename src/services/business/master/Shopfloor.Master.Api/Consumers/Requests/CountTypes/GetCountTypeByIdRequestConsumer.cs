using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.CountTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCountTypeByIdRequestConsumer : IConsumer<GetCountTypeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCountTypeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCountTypeByIdRequest> context)
        {
            Log.Warning($"GetCountTypeByIdRequestConsumer: request={context.Message.ToJson()}");

            var countTypes = await _mediator.Send(new GetCountTypeQuery() { Id = context.Message.Id });
            if (countTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetCountTypeByIdResponse
            {
                Id = countTypes.Data.Id,
                Code = countTypes.Data.Code,
                Name = countTypes.Data.Name,
                IsActive = countTypes.Data.IsActive
            };
            Log.Information($"GetCountTypeTypeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}