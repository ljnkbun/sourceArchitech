using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.CropSeasons;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCropSeasonsRequestConsumer : IConsumer<GetCropSeasonsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCropSeasonsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCropSeasonsRequest> context)
        {
            Log.Warning($"GetCropSeasonsRequestConsumer: request={context.Message.ToJson()}");

            var cropSeasons = await _mediator.Send(new GetCropSeasonsQuery()
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
            if (cropSeasons?.Data == null) await context.RespondAsync(null);
            var response = new GetCropSeasonsResponse
            {
                Data = cropSeasons.Data.Select(x => new GetCropSeasonByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetCropSeasonsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}