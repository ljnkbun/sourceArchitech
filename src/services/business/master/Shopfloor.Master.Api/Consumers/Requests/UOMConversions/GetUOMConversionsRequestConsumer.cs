using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.UOMConversions;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetUOMConversionsRequestConsumer : IConsumer<GetUOMConversionsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetUOMConversionsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetUOMConversionsRequest> context)
        {
            Log.Warning($"GetUOMConversionsRequestConsumer: request={context.Message.ToJson()}");

            var UOMConversions = await _mediator.Send(new GetUOMConversionsQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                FromUOMId = context.Message.FromUOMId,
                ToUOMId = context.Message.ToUOMId,
                Value = context.Message.Value,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (UOMConversions?.Data == null) await context.RespondAsync(null);
            var response = new GetUOMConversionsResponse
            {
                Data = UOMConversions.Data.Select(x => new GetUOMConversionByIdResponse
                {
                    Id = x.Id,
                    FromUOMId = x.FromUOMId,
                    ToUOMId = x.ToUOMId,
                    Value = x.Value,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetUOMConversionsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}