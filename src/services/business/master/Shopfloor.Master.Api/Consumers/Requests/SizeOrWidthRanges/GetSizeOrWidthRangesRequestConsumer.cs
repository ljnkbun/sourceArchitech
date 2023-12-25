using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SizeOrWidthRanges;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSizeOrWidthRangesRequestConsumer : IConsumer<GetSizeOrWidthRangesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSizeOrWidthRangesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSizeOrWidthRangesRequest> context)
        {
            Log.Warning($"GetSizeOrWidthRangesRequestConsumer: request={context.Message.ToJson()}");

            var sizeOrWidthRanges = await _mediator.Send(new GetSizeOrWidthRangesQuery()
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
            if (sizeOrWidthRanges?.Data == null) await context.RespondAsync(null);
            var response = new GetSizeOrWidthRangesResponse
            {
                Data = sizeOrWidthRanges.Data.Select(x => new GetSizeOrWidthRangeByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetSizeOrWidthRangesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}