using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Holidays;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetHolidayByIdRequestConsumer : IConsumer<GetHolidayByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetHolidayByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetHolidayByIdRequest> context)
        {
            Log.Warning($"GetHolidayByIdRequestConsumer: request={context.Message.ToJson()}");

            var res = await _mediator.Send(new GetHolidayQuery() { Id = context.Message.Id });
            if (res?.Data == null) await context.RespondAsync(null);
            var response = new GetHolidayByIdResponse
            {
                Id = res.Data.Id,
                Date = res.Data.Date,
                Description = res.Data.Description,
                IsActive = res.Data.IsActive
            };
            Log.Information($"GetHolidayByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}