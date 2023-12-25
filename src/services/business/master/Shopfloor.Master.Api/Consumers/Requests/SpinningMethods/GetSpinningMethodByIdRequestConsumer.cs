using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SpinningMethods;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSpinningMethodByIdRequestConsumer : IConsumer<GetSpinningMethodByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSpinningMethodByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSpinningMethodByIdRequest> context)
        {
            Log.Warning($"GetSpinningMethodByIdRequestConsumer: request={context.Message.ToJson()}");

            var spinningMethods = await _mediator.Send(new GetSpinningMethodQuery() { Id = context.Message.Id });
            if (spinningMethods?.Data == null) await context.RespondAsync(null);
            var response = new GetSpinningMethodByIdResponse
            {
                Id = spinningMethods.Data.Id,
                Code = spinningMethods.Data.Code,
                Name = spinningMethods.Data.Name,
                IsActive = spinningMethods.Data.IsActive
            };
            Log.Information($"GetSpinningMethodByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}