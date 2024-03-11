using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Barcode.Application.Query.ArticleBarcodes;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests.Barcodes;
using Shopfloor.EventBus.Models.Responses.Barcodes;

namespace Shopfloor.Barcode.Api.Consumers.Requests
{
    public class GetArticleBarcodeByBarcodesRequestConsumer : IConsumer<GetArticleBarcodeByBarcodesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetArticleBarcodeByBarcodesRequestConsumer(IMediator mediator
            , IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetArticleBarcodeByBarcodesRequest> context)
        {
            Log.Warning($"GetbarcodesRequestConsumer: request={context.Message.ToJson()}");

            var barcodes = await _mediator.Send(new GetArticleBarcodeByBarcodesQuery()
            {
                Barcodes = context.Message.Barcodes
            });
            var response = new GetArticleBarcodeByBarcodesResponse()
            {
                Data = _mapper.Map<List<ArticleBarcodeModel>>(barcodes.Data)
            };

            Log.Information($"GetGDIRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }

}