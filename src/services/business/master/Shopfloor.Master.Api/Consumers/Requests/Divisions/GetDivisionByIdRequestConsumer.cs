using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Divisions;
using Shopfloor.EventBus.Models.Responses.Divisions;
using Shopfloor.Master.Application.Query.Divisions;

namespace Shopfloor.Master.Api.Consumers.Requests.Divisions
{
    public class GetDivisionByIdRequestConsumer : IConsumer<GetDivisionByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetDivisionByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDivisionByIdRequest> context)
        {
            Log.Warning($"GetDivisionByIdRequestConsumer: request={context.Message.ToJson()}");

            var divisions = await _mediator.Send(new GetDivisionQuery() { Id = context.Message.Id });
            if (divisions?.Data == null) await context.RespondAsync(null);
            var response = new GetDivisionByIdResponse
            {
                Id = divisions.Data.Id,
                Code = divisions.Data.Code,
                Name = divisions.Data.Name,
                IsActive = divisions.Data.IsActive
            };
            Log.Information($"GetDivisionByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}