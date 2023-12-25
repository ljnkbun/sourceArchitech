using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.DeliveryTerms;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetDeliveryTermsRequestConsumer : IConsumer<GetDeliveryTermsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetDeliveryTermsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDeliveryTermsRequest> context)
        {
            Log.Warning($"GetDeliveryTermsRequestConsumer: request={context.Message.ToJson()}");

            var deliveryTerms = await _mediator.Send(new GetDeliveryTermsQuery()
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
            if (deliveryTerms?.Data == null) await context.RespondAsync(null);
            var response = new GetDeliveryTermsResponse
            {
                Data = deliveryTerms.Data.Select(x => new GetDeliveryTermByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetDeliveryTermsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}