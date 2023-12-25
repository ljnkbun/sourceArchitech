using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Counts;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCountByIdRequestConsumer : IConsumer<GetCountByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCountByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCountByIdRequest> context)
        {
            Log.Warning($"GetCountByIdRequestConsumer: request={context.Message.ToJson()}");

            var counts = await _mediator.Send(new GetCountQuery() { Id = context.Message.Id });
            if (counts?.Data == null) await context.RespondAsync(null);
            var response = new GetCountByIdResponse
            {
                Id = counts.Data.Id,
                Code = counts.Data.Code,
                Name = counts.Data.Name,
                IsActive = counts.Data.IsActive
            };
            Log.Information($"GetCountByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}