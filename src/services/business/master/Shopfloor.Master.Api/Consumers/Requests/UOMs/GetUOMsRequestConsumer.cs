using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.UOMs;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetUOMsRequestConsumer : IConsumer<GetUOMsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetUOMsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetUOMsRequest> context)
        {
            Log.Warning($"GetUOMsRequestConsumer: request={context.Message.ToJson()}");

            var uoms = await _mediator.Send(new GetUOMsQuery()
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
            if (uoms?.Data == null) await context.RespondAsync(null);
            var response = new GetUOMsResponse
            {
                Data = uoms.Data.Select(x => new GetUOMByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetUOMsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}