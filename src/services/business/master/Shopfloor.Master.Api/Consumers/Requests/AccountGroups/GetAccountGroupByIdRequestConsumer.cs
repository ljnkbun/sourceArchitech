using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.AccountGroups;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetAccountGroupByIdRequestConsumer : IConsumer<GetAccountGroupByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetAccountGroupByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetAccountGroupByIdRequest> context)
        {
            Log.Warning($"GetAccountGroupByIdRequestConsumer: request={context.Message.ToJson()}");

            var accountGroup = await _mediator.Send(new GetAccountGroupQuery() { Id = context.Message.Id });
            if (accountGroup?.Data == null) await context.RespondAsync(null);
            var response = new GetAccountGroupByIdResponse
            {
                Id = accountGroup.Data.Id,
                Code = accountGroup.Data.Code,
                Name = accountGroup.Data.Name,
                IsActive = accountGroup.Data.IsActive
            };
            Log.Information($"GetAccountGroupByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}