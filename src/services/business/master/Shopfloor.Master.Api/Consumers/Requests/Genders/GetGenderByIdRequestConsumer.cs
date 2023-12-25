using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Genders;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetGenderByIdRequestConsumer : IConsumer<GetGenderByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetGenderByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetGenderByIdRequest> context)
        {
            Log.Warning($"GetGenderByIdRequestConsumer: request={context.Message.ToJson()}");

            var genders = await _mediator.Send(new GetGenderQuery() { Id = context.Message.Id });
            if (genders?.Data == null) await context.RespondAsync(null);
            var response = new GetGenderByIdResponse
            {
                Id = genders.Data.Id,
                Code = genders.Data.Code,
                Name = genders.Data.Name,
                IsActive = genders.Data.IsActive
            };
            Log.Information($"GetGenderByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}