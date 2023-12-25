using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.MachineTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetMachineTypeByIdRequestConsumer : IConsumer<GetMachineTypeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMachineTypeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMachineTypeByIdRequest> context)
        {
            Log.Warning($"GetMachineTypeByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetMachineTypeQuery() { Id = context.Message.Id });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetMachineTypeByIdResponse
            {
                Id = structures.Data.Id,
                Code = structures.Data.Code,
                Name = structures.Data.Name,
                IsActive = structures.Data.IsActive
            };
            Log.Information($"GetMachineTypeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}