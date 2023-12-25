using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Origins;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetOriginsRequestConsumer : IConsumer<GetOriginsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetOriginsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetOriginsRequest> context)
        {
            Log.Warning($"GetOriginsRequestConsumer: request={context.Message.ToJson()}");

            var origins = await _mediator.Send(new GetOriginsQuery()
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
            if (origins?.Data == null) await context.RespondAsync(null);
            var response = new GetOriginsResponse
            {
                Data = origins.Data.Select(x => new GetOriginByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetOriginsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}