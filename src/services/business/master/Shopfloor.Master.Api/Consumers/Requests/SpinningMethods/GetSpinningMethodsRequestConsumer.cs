using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SpinningMethods;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSpinningMethodsRequestConsumer : IConsumer<GetSpinningMethodsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSpinningMethodsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSpinningMethodsRequest> context)
        {
            Log.Warning($"GetSpinningMethodsRequestConsumer: request={context.Message.ToJson()}");

            var spinningMethods = await _mediator.Send(new GetSpinningMethodsQuery()
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
            if (spinningMethods?.Data == null) await context.RespondAsync(null);
            var response = new GetSpinningMethodsResponse
            {
                Data = spinningMethods.Data.Select(x => new GetSpinningMethodByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetSpinningMethodsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}