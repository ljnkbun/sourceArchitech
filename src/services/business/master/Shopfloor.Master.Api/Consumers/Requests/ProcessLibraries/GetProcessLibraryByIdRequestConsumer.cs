using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ProcessLibraries;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetProcessLibraryByIdRequestConsumer : IConsumer<GetProcessLibraryByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetProcessLibraryByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetProcessLibraryByIdRequest> context)
        {
            Log.Warning($"GetGetProcessLibraryByIdRequestConsumer: request={context.Message.ToJson()}");

            var processLibRes = await _mediator.Send(new GetProcessLibraryQuery() { Id = context.Message.Id });
            if (processLibRes?.Data == null) await context.RespondAsync(null);
            var response = new GetProcessLibraryByIdResponse
            {
                Id = processLibRes.Data.Id,
                Code = processLibRes.Data.Code,
                Name = processLibRes.Data.Name,
                IsActive = processLibRes.Data.IsActive
            };
            Log.Information($"GetGetProcessLibraryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}