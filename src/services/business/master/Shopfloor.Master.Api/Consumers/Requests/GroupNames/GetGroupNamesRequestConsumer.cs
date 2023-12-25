using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.GroupNames;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetGroupNamesRequestConsumer : IConsumer<GetGroupNamesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetGroupNamesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetGroupNamesRequest> context)
        {
            Log.Warning($"GetGroupNamesRequestConsumer: request={context.Message.ToJson()}");

            var groupName = await _mediator.Send(new GetGroupNamesQuery()
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
            if (groupName?.Data == null) await context.RespondAsync(null);
            var response = new GetGroupNamesResponse
            {
                Data = groupName.Data.Select(x => new GetGroupNameByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetGroupNamesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}