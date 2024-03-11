using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Machines;
using Shopfloor.EventBus.Models.Responses.Masters.Machines;
using Shopfloor.Master.Application.Query.Machines;

namespace Shopfloor.Master.Api.Consumers.Requests.Machines
{
    public class GetMachineByIdRequestConsumer : IConsumer<GetMachineByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMachineByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMachineByIdRequest> context)
        {
            Log.Warning($"GetMachineByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetMachineQuery() { Id = context.Message.Id });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetMachineByIdResponse
            {
                Id = structures.Data.Id,
                Code = structures.Data.Code,
                Name = structures.Data.Name,
                SerialNo = structures.Data.SerialNo,
                Remarks = structures.Data.Remarks,
                Capacity = structures.Data.Capacity,
                FactoryId = structures.Data.FactoryId,
                ProcessId = structures.Data.ProcessId,
                Gauge = structures.Data.Gauge,
                MachineDiameter = structures.Data.MachineDiameter,
                IsActive = structures.Data.IsActive,
            };
            Log.Information($"GetMachineByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
