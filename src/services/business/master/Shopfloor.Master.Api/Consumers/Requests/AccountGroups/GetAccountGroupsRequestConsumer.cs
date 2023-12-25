using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.AccountGroups;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetAccountGroupsRequestConsumer : IConsumer<GetAccountGroupsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetAccountGroupsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetAccountGroupsRequest> context)
        {
            Log.Warning($"GetAccountGroupsRequestConsumer: request={context.Message.ToJson()}");

            var accountGroup = await _mediator.Send(new GetAccountGroupsQuery()
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
            if (accountGroup?.Data == null) await context.RespondAsync(null);
            var response = new GetAccountGroupsResponse
            {
                Data = accountGroup.Data.Select(x => new GetAccountGroupByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetAccountGroupsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}