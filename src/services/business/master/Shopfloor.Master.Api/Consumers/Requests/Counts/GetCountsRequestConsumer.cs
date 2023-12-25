using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Counts;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCountsRequestConsumer : IConsumer<GetCountsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCountsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCountsRequest> context)
        {
            Log.Warning($"GetCountsRequestConsumer: request={context.Message.ToJson()}");

            var counts = await _mediator.Send(new GetCountsQuery()
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
            if (counts?.Data == null) await context.RespondAsync(null);
            var response = new GetCountsResponse
            {
                Data = counts.Data.Select(x => new GetCountByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetCountsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}