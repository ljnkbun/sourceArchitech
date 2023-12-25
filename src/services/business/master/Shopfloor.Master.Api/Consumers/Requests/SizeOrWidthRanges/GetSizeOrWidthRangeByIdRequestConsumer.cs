using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.SizeOrWidthRanges;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetSizeOrWidthRangeByIdRequestConsumer : IConsumer<GetSizeOrWidthRangeByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetSizeOrWidthRangeByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetSizeOrWidthRangeByIdRequest> context)
        {
            Log.Warning($"GetSizeOrWidthRangeByIdRequestConsumer: request={context.Message.ToJson()}");

            var sizeOrWidthRanges = await _mediator.Send(new GetSizeOrWidthRangeQuery() { Id = context.Message.Id });
            if (sizeOrWidthRanges?.Data == null) await context.RespondAsync(null);
            var response = new GetSizeOrWidthRangeByIdResponse
            {
                Id = sizeOrWidthRanges.Data.Id,
                Code = sizeOrWidthRanges.Data.Code,
                Name = sizeOrWidthRanges.Data.Name,
                Inseam = sizeOrWidthRanges.Data.Inseam,
                SortOrder = sizeOrWidthRanges.Data.SortOrder,
                IsActive = sizeOrWidthRanges.Data.IsActive
            };
            Log.Information($"GetSizeOrWidthRangeByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}