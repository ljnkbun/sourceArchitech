using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Machines;
using Shopfloor.EventBus.Models.Responses.Masters.Machines;
using Shopfloor.Master.Application.Query.Machines;

namespace Shopfloor.Master.Api.Consumers.Requests.Machines
{
    public class GetMachinesRequestConsumer : IConsumer<GetMachinesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMachinesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMachinesRequest> context)
        {
            Log.Warning($"GetMachineRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetMachinesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                SerialNo = context.Message.SerialNo,
                Remarks = context.Message.Remarks,
                Capacity = context.Message.Capacity,
                FactoryId = context.Message.FactoryId,
                ProcessId = context.Message.ProcessId,
                Gauge = context.Message.Gauge,
                MachineDiameter = context.Message.MachineDiameter,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration,
            });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetMachinesResponse
            {
                Data = structures.Data.Select(x => new GetMachineByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    SerialNo = x.SerialNo,
                    Remarks = x.Remarks,
                    Capacity = x.Capacity,
                    FactoryId = x.FactoryId,
                    ProcessId = x.ProcessId,
                    Gauge = x.Gauge,
                    MachineDiameter = x.MachineDiameter,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetMachineRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
