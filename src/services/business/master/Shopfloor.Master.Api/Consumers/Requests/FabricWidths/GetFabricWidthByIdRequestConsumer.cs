using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.FabricWidths;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetFabricWidthByIdRequestConsumer : IConsumer<GetFabricWidthByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFabricWidthByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFabricWidthByIdRequest> context)
        {
            Log.Warning($"GetFabricWidthByIdRequestConsumer: request={context.Message.ToJson()}");

            var fabricWidths = await _mediator.Send(new GetFabricWidthQuery() { Id = context.Message.Id });
            if (fabricWidths?.Data == null) await context.RespondAsync(null);
            var response = new GetFabricWidthByIdResponse
            {
                Id = fabricWidths.Data.Id,
                Code = fabricWidths.Data.Code,
                Name = fabricWidths.Data.Name,
                SortOrder = fabricWidths.Data.SortOrder,
                Inseam = fabricWidths.Data.Inseam,
                IsActive = fabricWidths.Data.IsActive
            };
            Log.Information($"GetFabricWidthByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}