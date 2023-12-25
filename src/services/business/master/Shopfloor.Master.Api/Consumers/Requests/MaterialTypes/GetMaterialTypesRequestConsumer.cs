using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.MaterialTypes;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetMaterialTypesRequestConsumer : IConsumer<GetMaterialTypesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMaterialTypesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMaterialTypesRequest> context)
        {
            Log.Warning($"GetMaterialTypesRequestConsumer: request={context.Message.ToJson()}");

            var materialTypes = await _mediator.Send(new GetMaterialTypesQuery()
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
            if (materialTypes?.Data == null) await context.RespondAsync(null);
            var response = new GetMaterialTypesResponse
            {
                Data = materialTypes.Data.Select(x => new GetMaterialTypeByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetMaterialTypesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}