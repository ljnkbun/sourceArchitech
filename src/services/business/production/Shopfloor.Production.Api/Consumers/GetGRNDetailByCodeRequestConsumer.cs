using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.ProductionOutputs;
using Shopfloor.EventBus.Models.Responses.ProductionOutputs;
using Shopfloor.Production.Application.Query.ProductionOutputs;

namespace Shopfloor.Production.Api.Consumers
{
    public class GetGRNDetailByCodeRequestConsumer : IConsumer<GetGRNDetailByCodeRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetGRNDetailByCodeRequestConsumer(IMediator mediator
            , IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetGRNDetailByCodeRequest> context)
        {
            Log.Warning($"GetbarcodesRequestConsumer: request={context.Message.ToJson()}");

            var productionOutputRes = await _mediator.Send(new GetProductionOutputByCodeQuery()
            {
                Code = context.Message.Code,
            });
            var response = new GetGRNDetailByCodeResponse()
            {
                InspectionBySizes = _mapper.Map<List<InspectionBySizeDto>>(productionOutputRes.Data.InspectionBySizes),
                DefectCapturings = _mapper.Map<List<DefectCapturingDto>>(productionOutputRes.Data.DefectCapturings),
                Mesurements = _mapper.Map<List<MesurementDto>>(productionOutputRes.Data.Measurements),
            };

            Log.Information($"GetGDIRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }

}