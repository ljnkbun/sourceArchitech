using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Holidays;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetHolidaysRequestConsumer : IConsumer<GetHolidaysRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetHolidaysRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetHolidaysRequest> context)
        {
            Log.Warning($"GetHolidaysRequestConsumer: request={context.Message.ToJson()}");

            var Holiday = await _mediator.Send(new GetHolidaysQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                FromDate = context.Message.FromDate,
                ToDate = context.Message.ToDate,
                Description = context.Message.Description,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (Holiday?.Data == null) await context.RespondAsync(null);

            var response = new GetHolidaysResponse
            {
                Data = Holiday.Data.Select(x => new GetHolidayByIdResponse
                {
                    Id = x.Id,
                    Date = x.Date,
                    Description = x.Description,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetHolidaysRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}