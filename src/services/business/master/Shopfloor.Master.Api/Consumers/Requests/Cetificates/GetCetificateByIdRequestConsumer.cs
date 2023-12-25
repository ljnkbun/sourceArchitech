using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Certificates;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCetificateByIdRequestConsumer : IConsumer<GetCetificateByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCetificateByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCetificateByIdRequest> context)
        {
            Log.Warning($"GetCetificateByIdRequestConsumer: request={context.Message.ToJson()}");

            var certificates = await _mediator.Send(new GetCertificateQuery() { Id = context.Message.Id });
            if (certificates?.Data == null) await context.RespondAsync(null);
            var response = new GetCetificateByIdResponse
            {
                Id = certificates.Data.Id,
                Code = certificates.Data.Code,
                Name = certificates.Data.Name,
                IsActive = certificates.Data.IsActive
            };
            Log.Information($"GetCetificateByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}