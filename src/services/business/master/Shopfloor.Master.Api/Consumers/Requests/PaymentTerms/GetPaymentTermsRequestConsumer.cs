using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.PaymentTerms;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetPaymentTermsRequestConsumer : IConsumer<GetPaymentTermsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPaymentTermsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPaymentTermsRequest> context)
        {
            Log.Warning($"GetPaymentTermsRequestConsumer: request={context.Message.ToJson()}");

            var paymentTerms = await _mediator.Send(new GetPaymentTermsQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                CreditDays = context.Message.CreditDays,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (paymentTerms?.Data == null) await context.RespondAsync(null);
            var response = new GetPaymentTermsResponse
            {
                Data = paymentTerms.Data.Select(x => new GetPaymentTermByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    CreditDays = x.CreditDays,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetPaymentTermsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}