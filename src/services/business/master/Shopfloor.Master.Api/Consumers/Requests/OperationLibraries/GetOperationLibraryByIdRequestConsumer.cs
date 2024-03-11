using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.OperationLibraries;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetOperationLibraryByIdRequestConsumer : IConsumer<GetOperationLibraryByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetOperationLibraryByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetOperationLibraryByIdRequest> context)
        {
            Log.Warning($"GetGetOperationLibraryByIdRequestConsumer: request={context.Message.ToJson()}");

            var operationLibRes = await _mediator.Send(new GetOperationLibraryQuery() { Id = context.Message.Id });
            if (operationLibRes?.Data == null) await context.RespondAsync(null);
            var response = new GetOperationLibraryByIdResponse
            {
                Id = operationLibRes.Data.Id,
                Code = operationLibRes.Data.Code,
                Name = operationLibRes.Data.Name,
                ProcessId = operationLibRes.Data.ProcessId,
                IsActive = operationLibRes.Data.IsActive
            };
            Log.Information($"GetGetOperationLibraryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}