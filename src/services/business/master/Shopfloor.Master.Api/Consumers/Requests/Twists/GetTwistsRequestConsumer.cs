using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Twists;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetTwistsRequestConsumer : IConsumer<GetTwistsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetTwistsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetTwistsRequest> context)
        {
            Log.Warning($"GetTwistsRequestConsumer: request={context.Message.ToJson()}");

            var twists = await _mediator.Send(new GetTwistsQuery()
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
            if (twists?.Data == null) await context.RespondAsync(null);
            var response = new GetTwistsResponse
            {
                Data = twists.Data.Select(x => new GetTwistByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetTwistsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}