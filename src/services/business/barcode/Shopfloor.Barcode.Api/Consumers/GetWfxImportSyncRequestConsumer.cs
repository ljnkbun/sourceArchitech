using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Barcode.Application.Parameters.WfxImportSyncs;
using Shopfloor.Barcode.Application.Query.ImportArticles;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Barcode.Api.Consumers.Requests
{
    public class GetWfxImportSyncRequestConsumer : IConsumer<GetWfxImportSyncRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetWfxImportSyncRequestConsumer(IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxImportSyncRequest> context)
        {
            Log.Warning($"GetImportSyncRequestConsumer: request={context.Message.ToJson()}");
            var parameters = _mapper.Map<List<WfxImportSyncParameter>>(context.Message.Parameters);
            var data = await _mediator.Send(new GetWfxImportSyncsQuery()
            {
                Parameters = parameters
            });
            var response = new GetWfxImportSyncResponse()
            {
                Data = _mapper.Map<List<GetWfxImportSyncData>>(data.Data)
            };

            Log.Information($"GetGDIRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }

}