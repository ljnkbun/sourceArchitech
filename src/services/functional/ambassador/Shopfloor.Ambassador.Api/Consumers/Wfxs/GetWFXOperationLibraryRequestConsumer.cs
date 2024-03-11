using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Ambassador.Application.Query.Wfxs;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Ambassadors.Wfxs;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Api.Consumers.Wfxs
{
    public class GetWFXOperationLibraryRequestConsumer : IConsumer<GetWFXOperationLibraryRequest>
    {
        #region Initialization
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetWFXOperationLibraryRequestConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWFXOperationLibraryRequest> context)
        {
            try
            {
                Log.Warning($"GetWFXOperationLibraryConsumer: request={context.Message.ToJson()}");
                var r = await _mediator.Send(new WFXCommonDataGetDDLQuery()
                {
                    ObjectType = context.Message.ObjectType,
                    PageParam = context.Message.PageParam,
                });
                var response = new WFXOperationLibraryResponse
                {
                    Data = _mapper.Map<List<WFXOperationLibrary>>(r.Data),
                };
                Log.Information($"GetWFXOperationLibraryConsumer: response={response}");
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error($"GetWFXOperationLibraryConsumer: {ex}");
            }
        }

    }
}
