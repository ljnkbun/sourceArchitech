using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Themes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetThemeByIdRequestConsumer : IConsumer<GetThemeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetThemeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetThemeByIdRequest> context)
        {
            Log.Warning($"GetThemeByIdRequestConsumer: request={context.Message.ToJson()}");

            var themes = await _mediator.Send(new GetThemeQuery() { Id = context.Message.Id });
            if (themes?.Data == null) await context.RespondAsync(null);
            var response = new GetThemeByIdResponse
            {
                Id = themes.Data.Id,
                Code = themes.Data.Code,
                Name = themes.Data.Name,
                IsActive = themes.Data.IsActive
            };
            Log.Information($"GetThemeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}