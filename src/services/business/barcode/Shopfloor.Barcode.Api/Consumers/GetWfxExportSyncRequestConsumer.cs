using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Barcode.Application.Query.WfxExportSyncs;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Barcode.Api.Consumers.Requests
{
    public class GetWfxExportSyncRequestConsumer : IConsumer<GetWfxExportSyncRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetWfxExportSyncRequestConsumer(IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetWfxExportSyncRequest> context)
        {
            try
            {
                Log.Warning($"GetExportSyncRequestConsumer: request={context.Message.ToJson()}");

                var ExportSync = await _mediator.Send(new GetWfxExportSyncsQuery()
                {
                    PageSize = context.Message.PageSize,
                    PageNumber = context.Message.PageNumber,
                });
                var response = new GetWfxExportSyncResponse()
                {
                    Data = _mapper.Map<List<GetWfxExportSyncData>>(ExportSync.Data)
                };

                Log.Information($"GetGDIRequestConsumer: response={response}");
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }

}