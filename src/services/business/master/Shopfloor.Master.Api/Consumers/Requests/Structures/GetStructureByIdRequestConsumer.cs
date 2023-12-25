using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Structures;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetStructureByIdRequestConsumer : IConsumer<GetStructureByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetStructureByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetStructureByIdRequest> context)
        {
            Log.Warning($"GetStructureByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetStructureQuery() { Id = context.Message.Id });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetStructureByIdResponse
            {
                Id = structures.Data.Id,
                Code = structures.Data.Code,
                Name = structures.Data.Name,
                IsActive = structures.Data.IsActive
            };
            Log.Information($"GetStructureByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}