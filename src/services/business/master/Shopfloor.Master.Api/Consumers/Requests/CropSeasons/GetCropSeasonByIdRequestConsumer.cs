using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.CropSeasons;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCropSeasonByIdRequestConsumer : IConsumer<GetCropSeasonByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCropSeasonByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCropSeasonByIdRequest> context)
        {
            Log.Warning($"GetCropSeasonByIdRequestConsumer: request={context.Message.ToJson()}");

            var cropSeasons = await _mediator.Send(new GetCropSeasonQuery() { Id = context.Message.Id });
            if (cropSeasons?.Data == null) await context.RespondAsync(null);
            var response = new GetCropSeasonByIdResponse
            {
                Id = cropSeasons.Data.Id,
                Code = cropSeasons.Data.Code,
                Name = cropSeasons.Data.Name,
                IsActive = cropSeasons.Data.IsActive
            };
            Log.Information($"GetCropSeasonByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}