using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Api.Consumers.Requests
{
    public class GetWfxGDNRequestConsumer : IConsumer<GetWfxGDNRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetWfxGDNRequestConsumer(IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxGDNRequest> context)
        {
            Log.Warning($"GetGDNRequestConsumer: request={context.Message.ToJson()}");

            var GDN = await _mediator.Send(new GetWfxGDNQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                WFXAPIGDNMovementData = _mapper.Map<List<WFXAPIGDNMovementData>>(context.Message.WFXAPIGDNMovementData),
            });
            var response = new GetWfxGDNResponse
            {
                Data = _mapper.Map<List<GetWfxGDNDto>>(GDN.Data),
            };
            Log.Information($"GetGDNRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }

}