using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SupplierTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSupplierTypesRequestConsumer : IConsumer<GetSupplierTypesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSupplierTypesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSupplierTypesRequest> context)
        {
            Log.Warning($"GetSupplierTypesRequestConsumer: request={context.Message.ToJson()}");

            var supplierTypes = await _mediator.Send(new GetSupplierTypesQuery()
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
            if (supplierTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetSupplierTypesResponse
            {
                Data = supplierTypes.Data.Select(x => new GetSupplierTypeByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetSupplierTypesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}