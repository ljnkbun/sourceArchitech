using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Patterns;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetPatternsRequestConsumer : IConsumer<GetPatternsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPatternsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPatternsRequest> context)
        {
            Log.Warning($"GetPatternsRequestConsumer: request={context.Message.ToJson()}");

            var patterns = await _mediator.Send(new GetPatternsQuery()
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
            if (patterns?.Data == null) await context.RespondAsync(null);
            var response = new GetPatternsResponse
            {
                Data = patterns.Data.Select(x => new GetPatternByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetPatternsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}