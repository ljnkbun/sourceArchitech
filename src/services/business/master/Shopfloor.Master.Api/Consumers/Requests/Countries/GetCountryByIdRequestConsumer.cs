using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Countries;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCountryByIdRequestConsumer : IConsumer<GetCountryByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCountryByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCountryByIdRequest> context)
        {
            Log.Warning($"GetCountryByIdRequestConsumer: request={context.Message.ToJson()}");

            var Countrys = await _mediator.Send(new GetCountryQuery() { Id = context.Message.Id });
            if (Countrys?.Data == null) await context.RespondAsync(null);
            var response = new GetCountryByIdResponse
            {
                Id = Countrys.Data.Id,
                Code = Countrys.Data.Code,
                Name = Countrys.Data.Name,
                IsActive = Countrys.Data.IsActive
            };
            Log.Information($"GetCountryByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}