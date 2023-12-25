using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SubOperationLibraries;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSubOperationLibrariesRequestConsumer : IConsumer<GetSubOperationLibrariesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSubOperationLibrariesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSubOperationLibrariesRequest> context)
        {
            Log.Warning($"GetSubOperationLibrariesRequestConsumer: request={context.Message.ToJson()}");

            var subOperationLibraries = await _mediator.Send(new GetSubOperationLibrariesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                OperationLibraryId = context.Message.OperationLibraryId,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (subOperationLibraries?.Data == null) await context.RespondAsync(null);
            var response = new GetSubOperationLibrariesResponse
            {
                Data = subOperationLibraries.Data.Select(x => new GetSubOperationLibraryByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    OperationLibraryId = x.OperationLibraryId,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetSubOperationLibrariesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}