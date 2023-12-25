using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.UOMs;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetUOMByIdRequestConsumer : IConsumer<GetUOMByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetUOMByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetUOMByIdRequest> context)
        {
            Log.Warning($"GetUOMByIdRequestConsumer: request={context.Message.ToJson()}");

            var uoms = await _mediator.Send(new GetUOMQuery() { Id = context.Message.Id });
            if (uoms?.Data == null) await context.RespondAsync(null);
            var response = new GetUOMByIdResponse
            {
                Id = uoms.Data.Id,
                Code = uoms.Data.Code,
                Name = uoms.Data.Name,
                IsActive = uoms.Data.IsActive
            };
            Log.Information($"GetUOMByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}