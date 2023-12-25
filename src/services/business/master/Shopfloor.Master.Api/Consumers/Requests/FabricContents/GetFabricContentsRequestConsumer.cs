using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Themes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetFabricContentsRequestConsumer : IConsumer<GetFabricContentsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFabricContentsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFabricContentsRequest> context)
        {
            Log.Warning($"GetFabricContentsRequestConsumer: request={context.Message.ToJson()}");

            var currencies = await _mediator.Send(new GetThemesQuery()
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
            if (currencies?.Data == null) await context.RespondAsync(null);
            var response = new GetFabricContentsResponse
            {
                Data = currencies.Data.Select(x => new GetFabricContentByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetFabricContentsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}