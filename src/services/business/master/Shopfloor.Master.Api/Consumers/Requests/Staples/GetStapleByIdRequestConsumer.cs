using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Staples;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetStapleByIdRequestConsumer : IConsumer<GetStapleByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetStapleByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetStapleByIdRequest> context)
        {
            Log.Warning($"GetStapleByIdRequestConsumer: request={context.Message.ToJson()}");

            var staples = await _mediator.Send(new GetStapleQuery() { Id = context.Message.Id });
            if (staples?.Data == null) await context.RespondAsync(null);
            var response = new GetStapleByIdResponse
            {
                Id = staples.Data.Id,
                Code = staples.Data.Code,
                Name = staples.Data.Name,
                IsActive = staples.Data.IsActive
            };
            Log.Information($"GetStapleByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}