using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Lines;
using Shopfloor.EventBus.Models.Responses.Masters.Lines;
using Shopfloor.Master.Application.Query.Lines;

namespace Shopfloor.Master.Api.Consumers.Requests.Lines
{
    public class GetLinesRequestConsumer : IConsumer<GetLinesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetLinesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetLinesRequest> context)
        {
            Log.Warning($"GetLinesRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetLinesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                Worker = context.Message.Worker,
                WFXLineId = context.Message.WFXLineId,
                FactoryId = context.Message.FactoryId,
                ProcessId = context.Message.ProcessId,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration,
            });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetLinesResponse
            {
               Data = structures.Data.Select(x=> new GetLineByIdResponse
               {
                   Id = x.Id,
                   Code = x.Code,
                   Name = x.Name,
                   Worker = x.Worker,
                   WFXLineId = x.WFXLineId,
                   FactoryId = x.FactoryId,
                   ProcessId = x.ProcessId,
                   IsActive = x.IsActive,
               }).ToList()
            };
            Log.Information($"GetLinesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
