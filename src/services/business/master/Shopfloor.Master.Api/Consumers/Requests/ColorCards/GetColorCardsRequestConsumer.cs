using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ColorCards;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetColorCardsRequestConsumer : IConsumer<GetColorCardsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetColorCardsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetColorCardsRequest> context)
        {
            Log.Warning($"GetColorCardsRequestConsumer: request={context.Message.ToJson()}");

            var colorCards = await _mediator.Send(new GetColorCardsQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                Reference = context.Message.Reference,
                BuyerCode = context.Message.BuyerCode,
                BuyerName = context.Message.BuyerName,
                SelectColor = context.Message.SelectColor,
                PictureURL = context.Message.PictureURL,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (colorCards?.Data == null) await context.RespondAsync(null);
            var response = new GetColorCardsResponse
            {
                Data = colorCards.Data.Select(x => new GetColorCardByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Reference = x.Reference,
                    BuyerCode = x.BuyerCode,
                    BuyerName = x.BuyerName,
                    SelectColor = x.SelectColor,
                    PictureURL = x.PictureURL,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetColorCardsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}