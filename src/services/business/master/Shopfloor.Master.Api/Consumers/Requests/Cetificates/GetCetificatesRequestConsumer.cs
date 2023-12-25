using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Certificates;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetCetificatesRequestConsumer : IConsumer<GetCetificatesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetCetificatesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetCetificatesRequest> context)
        {
            Log.Warning($"GetCetificatesRequestConsumer: request={context.Message.ToJson()}");

            var certificates = await _mediator.Send(new GetCertificatesQuery()
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
            if (certificates?.Data == null) await context.RespondAsync(null);
            var response = new GetCetificatesResponse
            {
                Data = certificates.Data.Select(x => new GetCetificateByIdResponse
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    IsActive = x.IsActive
                }).ToList()
            };
            Log.Information($"GetCetificatesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}