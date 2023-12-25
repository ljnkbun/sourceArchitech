using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.MachineTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetMachineTypesRequestConsumer : IConsumer<GetMachineTypesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMachineTypesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMachineTypesRequest> context)
        {
            Log.Warning($"GetMachineTypesRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetMachineTypesQuery()
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
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetMachineTypesResponse
            {
                Data = structures.Data.Select(x => new GetMachineTypeByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetMachineTypesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}