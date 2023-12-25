using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ImportDetails;
using Shopfloor.Barcode.Domain.Interfaces;


namespace Shopfloor.Barcode.Application.Query.ImportDetails
{
    public class PrintImportDetailsQuery : IRequest<ICollection<PrintImportDetailModel>>
    {
       public string Ids { get; set; }
    }
    public class PrintImportDetailsQueryHandler : IRequestHandler<PrintImportDetailsQuery, ICollection<PrintImportDetailModel>>
    {
        private readonly IMapper _mapper;
        private readonly IImportDetailRepository _repository;
        public PrintImportDetailsQueryHandler(IMapper mapper,
            IImportDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ICollection<PrintImportDetailModel>> Handle(PrintImportDetailsQuery request, CancellationToken cancellationToken)
        {
            var intIds = request.Ids.Split(',').Select(x=>Convert.ToInt32(x)).ToArray();
            return await _repository.PrintImportDetail<PrintImportDetailModel>(intIds);
        }
    }
}
