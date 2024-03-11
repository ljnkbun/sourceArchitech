using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Plannings.FPPOs;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Planning.Application.Query.FPPOs;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetFPPOsRequestConsumer : IConsumer<GetFPPOsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetFPPOsRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetFPPOsRequest> context)
        {
            Log.Warning($"GetFPPOsRequestConsumer: request={context.Message.ToJson()}");

            var fppos = await _mediator.Send(new GetFPPOsQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                IsActive = context.Message.IsActive,

                StripScheduleId = context.Message.StripScheduleId,
                WFXFPPOId = context.Message.WFXFPPOId,
                FPPONo = context.Message.FPPONo,
                WFXOCId = context.Message.WFXOCId,
                OCNo = context.Message.OCNo,
                WFXDeliveryOrderCode = context.Message.WFXDeliveryOrderCode,
                Supplier = context.Message.Supplier,
                WipDispatchSite = context.Message.WipDispatchSite,
                WipReceivingSite = context.Message.WipReceivingSite,
                PORId = context.Message.PORId,
                PORNo = context.Message.PORNo,
                BatchNo = context.Message.BatchNo,
                JobOrderNo = context.Message.JobOrderNo,
                FactoryId = context.Message.FactoryId,
                LineId = context.Message.LineId,
                MachineId = context.Message.MachineId,
                ProcessId = context.Message.ProcessId,
                ProcessCode = context.Message.ProcessCode,
                ProcessName = context.Message.ProcessName,
                Start = context.Message.Start,
                End = context.Message.End,
                WFXArticleId = context.Message.WFXArticleId,
                ArticleName = context.Message.ArticleName,
                ArticleCode = context.Message.ArticleCode,
                UOM = context.Message.UOM,
                WFXSynced = context.Message.WFXSynced,
                Deleted = context.Message.Deleted
            });

            if (fppos?.Data == null) await context.RespondAsync(null);

            var response = new GetFPPOsResponse
            {
                Data = fppos.Data.Select(x => new GetFPPOByIdResponse
                {
                    Id = x.Id,
                    StripScheduleId = x.StripScheduleId,
                    WFXFPPOId = x.WFXFPPOId,
                    FPPONo = x.FPPONo,
                    WFXOCId = x.WFXOCId,
                    OCNo = x.OCNo,
                    WFXDeliveryOrderCode = x.WFXDeliveryOrderCode,
                    Supplier = x.Supplier,
                    WipDispatchSite = x.WipDispatchSite,
                    WipReceivingSite = x.WipReceivingSite,
                    PORId = x.PORId,
                    PORNo = x.PORNo,
                    BatchNo = x.BatchNo,
                    JobOrderNo = x.JobOrderNo,
                    FactoryId = x.FactoryId,
                    LineId = x.LineId,
                    MachineId = x.MachineId,
                    ProcessId = x.ProcessId,
                    ProcessCode = x.ProcessCode,
                    ProcessName = x.ProcessName,
                    Start = x.Start,
                    End = x.End,
                    WFXArticleId = x.WFXArticleId,
                    ArticleName = x.ArticleName,
                    ArticleCode = x.ArticleCode,
                    UOM = x.UOM,
                    WFXSynced = x.WFXSynced,
                    Deleted = x.Deleted
                }).ToList()
            };
            Log.Information($"GetFPPOsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}