using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Ports;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetPortsRequestConsumer : IConsumer<GetPortsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetPortsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetPortsRequest> context)
        {
            Log.Warning($"GetPortsRequestConsumer: request={context.Message.ToJson()}");

            var ports = await _mediator.Send(new GetPortsQuery()
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
            if (ports?.Data == null) await context.RespondAsync(null);
            var response = new GetPortsResponse
            {
                Data = ports.Data.Select(x => new GetPortByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetPortsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}