using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ShipmentTerms;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetShipmentTermsRequestConsumer : IConsumer<GetShipmentTermsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetShipmentTermsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetShipmentTermsRequest> context)
        {
            Log.Warning($"GetShipmentTermsRequestConsumer: request={context.Message.ToJson()}");

            var shipmentTerms = await _mediator.Send(new GetShipmentTermsQuery()
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
            if (shipmentTerms?.Data == null) await context.RespondAsync(null);
            var response = new GetShipmentTermsResponse
            {
                Data = shipmentTerms.Data.Select(x => new GetShipmentTermByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetShipmentTermsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}