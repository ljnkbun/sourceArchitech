using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SpinningProcesses;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSpinningProcessByIdRequestConsumer : IConsumer<GetSpinningProcessByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSpinningProcessByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSpinningProcessByIdRequest> context)
        {
            Log.Warning($"GetSpinningProcessByIdRequestConsumer: request={context.Message.ToJson()}");

            var spinningProcesss = await _mediator.Send(new GetSpinningProcessQuery() { Id = context.Message.Id });
            if (spinningProcesss?.Data == null) await context.RespondAsync(null);
            var response = new GetSpinningProcessByIdResponse
            {
                Id = spinningProcesss.Data.Id,
                Code = spinningProcesss.Data.Code,
                Name = spinningProcesss.Data.Name,
                IsActive = spinningProcesss.Data.IsActive
            };
            Log.Information($"GetSpinningProcessByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}