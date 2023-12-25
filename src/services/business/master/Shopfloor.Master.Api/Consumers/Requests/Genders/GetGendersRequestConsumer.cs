using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Genders;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetGendersRequestConsumer : IConsumer<GetGendersRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetGendersRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetGendersRequest> context)
        {
            Log.Warning($"GetGendersRequestConsumer: request={context.Message.ToJson()}");

            var genders = await _mediator.Send(new GetGendersQuery()
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
            if (genders?.Data == null) await context.RespondAsync(null);
            var response = new GetGendersResponse
            {
                Data = genders.Data.Select(x => new GetGenderByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetGendersRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}