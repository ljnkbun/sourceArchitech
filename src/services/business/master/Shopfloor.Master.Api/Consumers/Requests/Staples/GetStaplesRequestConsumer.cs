using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Staples;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetStaplesRequestConsumer : IConsumer<GetStaplesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetStaplesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetStaplesRequest> context)
        {
            Log.Warning($"GetStaplesRequestConsumer: request={context.Message.ToJson()}");

            var staples = await _mediator.Send(new GetStaplesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (staples?.Data == null) await context.RespondAsync(null);
            var response = new GetStaplesResponse
            {
                Data = staples.Data.Select(x => new GetStapleByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetStaplesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}