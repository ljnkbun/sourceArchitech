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
    public class GetWfxGDIRequestConsumer : IConsumer<GetWfxGDIRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetWfxGDIRequestConsumer(IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxGDIRequest> context)
        {
            Log.Warning($"GetGDIRequestConsumer: request={context.Message.ToJson()}");

            var GDI = await _mediator.Send(new GetWfxGDIQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                WFXAPIGDIMovementData = _mapper.Map<List<WFXAPIGDIMovementData>>(context.Message.WFXAPIGDIMovementData),
            });
            var response = new GetWfxGDIResponse
            {
                Data = _mapper.Map<List<GetWfxGDIDto>>(GDI.Data),
            };
            Log.Information($"GetGDIRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }

}