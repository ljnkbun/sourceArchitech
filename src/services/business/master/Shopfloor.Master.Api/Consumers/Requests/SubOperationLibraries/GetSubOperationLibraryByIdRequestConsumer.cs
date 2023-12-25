using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SubOperationLibraries;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSubOperationLibraryByIdRequestConsumer : IConsumer<GetSubOperationLibraryByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSubOperationLibraryByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSubOperationLibraryByIdRequest> context)
        {
            Log.Warning($"GetGetSubOperationLibraryByIdRequestConsumer: request={context.Message.ToJson()}");

            var subOperationLibraryRes = await _mediator.Send(new GetSubOperationLibraryQuery() { Id = context.Message.Id });
            if (subOperationLibraryRes?.Data == null) await context.RespondAsync(null);
            var response = new GetSubOperationLibraryByIdResponse
            {
                Id = subOperationLibraryRes.Data.Id,
                Code = subOperationLibraryRes.Data.Code,
                Name = subOperationLibraryRes.Data.Name,
                OperationLibraryId = subOperationLibraryRes.Data.OperationLibraryId,
                IsActive = subOperationLibraryRes.Data.IsActive
            };
            Log.Information($"GetGetSubOperationLibraryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}