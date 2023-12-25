using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Themes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetThemesRequestConsumer : IConsumer<GetThemesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetThemesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetThemesRequest> context)
        {
            Log.Warning($"GetThemesRequestConsumer: request={context.Message.ToJson()}");

            var themes = await _mediator.Send(new GetThemesQuery()
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
            if (themes?.Data == null) await context.RespondAsync(null);
            var response = new GetThemesResponse
            {
                Data = themes.Data.Select(x => new GetThemeByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetThemesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}