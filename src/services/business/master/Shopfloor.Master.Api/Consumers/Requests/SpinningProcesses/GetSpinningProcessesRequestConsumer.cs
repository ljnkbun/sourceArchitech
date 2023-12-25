using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SpinningProcesses;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSpinningProcessesRequestConsumer : IConsumer<GetSpinningProcessesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSpinningProcessesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSpinningProcessesRequest> context)
        {
            Log.Warning($"GetSpinningProcessesRequestConsumer: request={context.Message.ToJson()}");

            var spinningProcesses = await _mediator.Send(new GetSpinningProcessesQuery()
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
            var response = new GetSpinningProcessesResponse
            {
                Data = spinningProcesses.Data.Select(x => new GetSpinningProcessByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetSpinningProcessesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}