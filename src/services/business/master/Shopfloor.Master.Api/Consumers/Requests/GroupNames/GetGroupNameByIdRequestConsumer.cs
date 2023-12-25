using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.GroupNames;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetGroupNameByIdRequestConsumer : IConsumer<GetGroupNameByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetGroupNameByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetGroupNameByIdRequest> context)
        {
            Log.Warning($"GetGroupNameByIdRequestConsumer: request={context.Message.ToJson()}");

            var groupName = await _mediator.Send(new GetGroupNameQuery() { Id = context.Message.Id });
            if (groupName?.Data == null) await context.RespondAsync(null);
            var response = new GetGroupNameByIdResponse
            {
                Id = groupName.Data.Id,
                Code = groupName.Data.Code,
                Name = groupName.Data.Name,
                IsActive = groupName.Data.IsActive
            };
            Log.Information($"GetGroupNameByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}