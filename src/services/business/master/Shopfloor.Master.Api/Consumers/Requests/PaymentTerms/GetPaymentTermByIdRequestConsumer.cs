using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.PaymentTerms;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetPaymentTermByIdRequestConsumer : IConsumer<GetPaymentTermByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPaymentTermByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPaymentTermByIdRequest> context)
        {
            Log.Warning($"GetPaymentTermByIdRequestConsumer: request={context.Message.ToJson()}");

            var paymentTerms = await _mediator.Send(new GetPaymentTermQuery() { Id = context.Message.Id });
            if (paymentTerms?.Data == null) await context.RespondAsync(null);
            var response = new GetPaymentTermByIdResponse
            {
                Id = paymentTerms.Data.Id,
                Code = paymentTerms.Data.Code,
                Name = paymentTerms.Data.Name,
                CreditDays = paymentTerms.Data.CreditDays,
                IsActive = paymentTerms.Data.IsActive
            };
            Log.Information($"GetPaymentTermByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}