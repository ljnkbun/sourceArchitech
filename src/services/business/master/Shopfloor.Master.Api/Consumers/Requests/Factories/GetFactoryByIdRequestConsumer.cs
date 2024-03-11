using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Masters.Factories;
using Shopfloor.EventBus.Models.Responses.Masters.Factories;
using Shopfloor.Master.Application.Query.Factories;

namespace Shopfloor.Master.Api.Consumers.Requests.Factories
{
    public class GetFactoryByIdRequestConsumer : IConsumer<GetFactoryByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFactoryByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFactoryByIdRequest> context)
        {
            Log.Warning($"GetFactoryByIdRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetFactoryQuery() { Id = context.Message.Id });
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetFactoryByIdResponse
            {
                Id = structures.Data.Id,
                Code = structures.Data.Code,
                Name = structures.Data.Name,
                DivisionId = structures.Data.DivisionId,
            };
            Log.Information($"GetFactoryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}
