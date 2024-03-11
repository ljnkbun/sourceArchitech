using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests.Barcodes;
using Shopfloor.EventBus.Models.Responses.Barcodes;
using Shopfloor.EventBus.Services;
using Shopfloor.Production.Application.Models.InspectionBySizes;

namespace Shopfloor.Production.Application.Command.InspectionBySizes
{
    public class PrintBarcodeCommand : IRequest<Response<ICollection<PrintBarcodeModel>>>
    {
        public string Barcodes { get; set; }
    }
    public class PrintBarcodeCommandHandler : IRequestHandler<PrintBarcodeCommand, Response<ICollection<PrintBarcodeModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestClientService _requestClientService;

        public PrintBarcodeCommandHandler(IMapper mapper
            , IRequestClientService requestClientService
            )
        {
            _requestClientService = requestClientService;
            _mapper = mapper;
        }

        public async Task<Response<ICollection<PrintBarcodeModel>>> Handle(PrintBarcodeCommand request, CancellationToken cancellationToken)
        {

            var resp = await _requestClientService.GetResponseAsync<GetArticleBarcodeByBarcodesRequest, GetArticleBarcodeByBarcodesResponse>(
                new GetArticleBarcodeByBarcodesRequest()
                {
                    Barcodes = request.Barcodes
                }, cancellationToken);
            if (resp == null) return default;

            var rs = _mapper.Map<List<PrintBarcodeModel>>(resp.Message.Data);

            return new Response<ICollection<PrintBarcodeModel>>(rs);
        }
    }
}
