using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Structures;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetStructuresRequestConsumer : IConsumer<GetStructuresRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetStructuresRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetStructuresRequest> context)
        {
            Log.Warning($"GetStructuresRequestConsumer: request={context.Message.ToJson()}");

            var structures = await _mediator.Send(new GetStructuresQuery()
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
            if (structures?.Data == null) await context.RespondAsync(null);
            var response = new GetStructuresResponse
            {
                Data = structures.Data.Select(x => new GetStructureByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetStructuresRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}