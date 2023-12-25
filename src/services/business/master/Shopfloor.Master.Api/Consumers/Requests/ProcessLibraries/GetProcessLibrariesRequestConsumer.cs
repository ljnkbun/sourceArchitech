using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.ProcessLibraries;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetProcessLibrariesRequestConsumer : IConsumer<GetProcessLibrariesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetProcessLibrariesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetProcessLibrariesRequest> context)
        {
            Log.Warning($"GetProcessLibrariesRequestConsumer: request={context.Message.ToJson()}");

            var processLibraries = await _mediator.Send(new GetProcessLibrariesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                Code = context.Message.Code,
                Name = context.Message.Name,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration
            });
            if (processLibraries?.Data == null) await context.RespondAsync(null);
            var response = new GetProcessLibrariesResponse
            {
                Data = processLibraries.Data.Select(x => new GetProcessLibraryByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetProcessLibrariesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}