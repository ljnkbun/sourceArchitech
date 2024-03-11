using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Planning.Application.Query.FPPOs;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetFPPOByIdRequestConsumer : IConsumer<GetFPPOByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFPPOByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFPPOByIdRequest> context)
        {
            Log.Warning($"GetFPPOByIdRequestConsumer: request={context.Message.ToJson()}");

            var fppo = await _mediator.Send(new GetFPPOQuery() { Id = context.Message.Id });
            if (fppo?.Data == null) await context.RespondAsync(null);
            var response = new GetFPPOByIdResponse
            {
                Id = fppo.Data.Id,
                StripScheduleId = fppo.Data.StripScheduleId,
                WFXFPPOId = fppo.Data.WFXFPPOId,
                FPPONo = fppo.Data.FPPONo,
                WFXOCId = fppo.Data.WFXOCId,
                OCNo = fppo.Data.OCNo,
                WFXDeliveryOrderCode = fppo.Data.WFXDeliveryOrderCode,
                Supplier = fppo.Data.Supplier,
                WipDispatchSite = fppo.Data.WipDispatchSite,
                WipReceivingSite = fppo.Data.WipReceivingSite,
                PORId = fppo.Data.PORId,
                PORNo = fppo.Data.PORNo,
                BatchNo = fppo.Data.BatchNo,
                JobOrderNo = fppo.Data.JobOrderNo,
                FactoryId = fppo.Data.FactoryId,
                LineId = fppo.Data.LineId,
                MachineId = fppo.Data.MachineId,
                ProcessId = fppo.Data.ProcessId,
                ProcessCode = fppo.Data.ProcessCode,
                ProcessName = fppo.Data.ProcessName,
                Start = fppo.Data.Start,
                End = fppo.Data.End,
                WFXArticleId = fppo.Data.WFXArticleId,
                ArticleName = fppo.Data.ArticleName,
                ArticleCode = fppo.Data.ArticleCode,
                UOM = fppo.Data.UOM,
                WFXSynced = fppo.Data.WFXSynced,
                Deleted = fppo.Data.Deleted
            };
            Log.Information($"GetFPPOByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}