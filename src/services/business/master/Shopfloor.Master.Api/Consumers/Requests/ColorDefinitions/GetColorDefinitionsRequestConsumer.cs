using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ColorDefinitions;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetColorDefinitionsRequestConsumer : IConsumer<GetColorDefinitionsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetColorDefinitionsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetColorDefinitionsRequest> context)
        {
            Log.Warning($"GetColorDefinitionsRequestConsumer: request={context.Message.ToJson()}");

            var colorDefinitions = await _mediator.Send(new GetColorDefinitionsQuery()
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
            if (colorDefinitions?.Data == null) await context.RespondAsync(null);
            var response = new GetColorDefinitionsResponse
            {
                Data = colorDefinitions.Data.Select(x => new GetColorDefinitionByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetColorDefinitionsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}