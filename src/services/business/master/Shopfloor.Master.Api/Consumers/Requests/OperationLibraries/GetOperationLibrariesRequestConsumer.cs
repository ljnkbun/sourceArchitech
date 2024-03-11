using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.OperationLibraries;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetOperationLibrariesRequestConsumer : IConsumer<GetOperationLibrariesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetOperationLibrariesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetOperationLibrariesRequest> context)
        {
            Log.Warning($"GetOperationLibrariesRequestConsumer: request={context.Message.ToJson()}");

            var operationLibraries = await _mediator.Send(new GetOperationLibrariesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                ProcessId = context.Message.ProcessId,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (operationLibraries?.Data == null) await context.RespondAsync(null);
            var response = new GetOperationLibrariesResponse
            {
                Data = operationLibraries.Data.Select(x => new GetOperationLibraryByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    ProcessId = x.ProcessId,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetOperationLibrariesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}