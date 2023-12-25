using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Micronaires;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetMicronairesRequestConsumer : IConsumer<GetMicronairesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetMicronairesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetMicronairesRequest> context)
        {
            Log.Warning($"GetMicronairesRequestConsumer: request={context.Message.ToJson()}");

            var micronaires = await _mediator.Send(new GetMicronairesQuery()
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
            if (micronaires?.Data == null) await context.RespondAsync(null);
            var response = new GetMicronairesResponse
            {
                Data = micronaires.Data.Select(x => new GetMicronaireByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetMicronairesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}