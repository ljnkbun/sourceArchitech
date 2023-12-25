using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Strengths;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetStrengthsRequestConsumer : IConsumer<GetStrengthsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetStrengthsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetStrengthsRequest> context)
        {
            Log.Warning($"GetStrengthsRequestConsumer: request={context.Message.ToJson()}");

            var strengths = await _mediator.Send(new GetStrengthsQuery()
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
            if (strengths?.Data == null) await context.RespondAsync(null);
            var response = new GetStrengthsResponse
            {
                Data = strengths.Data.Select(x => new GetStrengthByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetStrengthsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}