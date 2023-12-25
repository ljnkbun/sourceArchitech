using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ColorCards;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetColorCardByIdRequestConsumer : IConsumer<GetColorCardByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetColorCardByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetColorCardByIdRequest> context)
        {
            Log.Warning($"GetColorCardByIdRequestConsumer: request={context.Message.ToJson()}");

            var colorCards = await _mediator.Send(new GetColorCardQuery() { Id = context.Message.Id });
            if (colorCards?.Data == null) await context.RespondAsync(null);
            var response = new GetColorCardByIdResponse
            {
                Id = colorCards.Data.Id,
                Code = colorCards.Data.Code,
                Name = colorCards.Data.Name,
                Reference = colorCards.Data.Reference,
                BuyerCode = colorCards.Data.BuyerCode,
                BuyerName = colorCards.Data.BuyerName,
                SelectColor = colorCards.Data.SelectColor,
                PictureURL = colorCards.Data.PictureURL,
                IsActive = colorCards.Data.IsActive
            };
            Log.Information($"GetColorCardByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}