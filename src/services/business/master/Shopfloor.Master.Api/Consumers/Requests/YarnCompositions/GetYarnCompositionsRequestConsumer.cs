using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.YarnCompositions;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetYarnCompositionsRequestConsumer : IConsumer<GetYarnCompositionsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetYarnCompositionsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetYarnCompositionsRequest> context)
        {
            Log.Warning($"GetCompositionsRequestConsumer: request={context.Message.ToJson()}");

            var yarnCompositions = await _mediator.Send(new GetYarnCompositionsQuery()
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
            if (yarnCompositions?.Data == null) await context.RespondAsync(null);
            var response = new GetYarnCompositionsResponse
            {
                Data = yarnCompositions.Data.Select(x => new GetYarnCompositionByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetCompositionsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}