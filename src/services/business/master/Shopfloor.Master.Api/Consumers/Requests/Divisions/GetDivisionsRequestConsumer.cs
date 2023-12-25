using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Divisions;
using Shopfloor.EventBus.Models.Responses.Divisions;
using Shopfloor.Master.Application.Query.Divisions;

namespace Shopfloor.Master.Api.Consumers.Requests.Divisions
{
    public class GetDivisionsRequestConsumer : IConsumer<GetDivisionsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetDivisionsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetDivisionsRequest> context)
        {
            Log.Warning($"GetDivisionsRequestConsumer: request={context.Message.ToJson()}");

            var divisions = await _mediator.Send(new GetDivisionsQuery()
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
            if (divisions?.Data == null) await context.RespondAsync(null);
            var response = new GetDivisionsResponse
            {
                Data = divisions.Data.Select(x => new GetDivisionByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetDivisionsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}