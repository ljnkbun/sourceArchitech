using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Constructions;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetConstructionsRequestConsumer : IConsumer<GetConstructionsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetConstructionsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetConstructionsRequest> context)
        {
            Log.Warning($"GetConstructionsRequestConsumer: request={context.Message.ToJson()}");

            var constructions = await _mediator.Send(new GetConstructionsQuery()
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
            if (constructions?.Data == null) await context.RespondAsync(null);
            var response = new GetConstructionsResponse
            {
                Data = constructions.Data.Select(x => new GetConstructionByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetConstructionsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}