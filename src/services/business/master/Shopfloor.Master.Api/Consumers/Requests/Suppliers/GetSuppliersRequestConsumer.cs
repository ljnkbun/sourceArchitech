using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Suppliers;
using Shopfloor.EventBus.Models.Responses.Masters.Suppliers;
using Shopfloor.Master.Application.Query.Suppliers;

namespace Shopfloor.Master.Api.Consumers.Requests.Suppliers
{
    public class GetSuppliersRequestConsumer : IConsumer<GetSuppliersRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSuppliersRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSuppliersRequest> context)
        {
            Log.Warning($"GetSuppliersRequestConsumer: request={context.Message.ToJson()}");

            var suppliers = await _mediator.Send(new GetSuppliersQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                WFXSupplierId = context.Message.WFXSupplierId,
                Name = context.Message.Name,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (suppliers?.Data == null) await context.RespondAsync(null);
            var response = new GetSuppliersResponse
            {
                Data = suppliers.Data.Select(x => new GetSupplierByIdResponse
                {
                    Id = x.Id,
                    WFXSupplierId = x.WFXSupplierId,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetSuppliersRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}