using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Processes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetProcessesRequestConsumer : IConsumer<GetProcessesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetProcessesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetProcessesRequest> context)
        {
            Log.Warning($"GetProcessesRequestConsumer: request={context.Message.ToJson()}");

            var spinningProcesses = await _mediator.Send(new GetProcessesQuery()
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
            if (spinningProcesses?.Data == null) await context.RespondAsync(null);
            var response = new GetProcessesResponse
            {
                Data = spinningProcesses.Data.Select(x => new GetProcessByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetProcessesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}