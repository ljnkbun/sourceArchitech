using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.FabricWidths;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetFabricWidthsRequestConsumer : IConsumer<GetFabricWidthsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFabricWidthsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFabricWidthsRequest> context)
        {
            Log.Warning($"GetFabricWidthsRequestConsumer: request={context.Message.ToJson()}");

            var fabricWidths = await _mediator.Send(new GetFabricWidthsQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                SortOrder = context.Message.SortOrder,
                Inseam = context.Message.Inseam,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (fabricWidths?.Data == null) await context.RespondAsync(null);
            var response = new GetFabricWidthsResponse
            {
                Data = fabricWidths.Data.Select(x => new GetFabricWidthByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Inseam = x.Inseam,
                    SortOrder = x.SortOrder,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetFabricWidthsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}