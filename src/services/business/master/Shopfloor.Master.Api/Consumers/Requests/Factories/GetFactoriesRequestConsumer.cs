using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Factories;
using Shopfloor.EventBus.Models.Responses.Masters.Factories;
using Shopfloor.Master.Application.Query.Factories;

namespace Shopfloor.Master.Api.Consumers.Requests.Factories
{
    public class GetFactoriesRequestConsumer : IConsumer<GetFactoriesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFactoriesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFactoriesRequest> context)
        {
            Log.Warning($"GetFactoriesRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetFactoriesQuery()
            {
                DivisionId = context.Message.DivisionId,
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
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetFactoriesResponse
            {
                Data = structures.Data.Select(x => new GetFactoryByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    DivisionId = x.DivisionId,
                    DivisionCode = x.DivisionCode,
                    ProcessIds = x.ProcessIds,
                }).ToList()
            };

            Log.Information($"GetFactoriesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
