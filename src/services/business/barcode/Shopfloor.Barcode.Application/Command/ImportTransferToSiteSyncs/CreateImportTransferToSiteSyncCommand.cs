using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportTransferToSiteSyns
{
    public class CreateImportTransferToSiteSyncCommand : IRequest<Response<int>>
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? Qty { get; set; }
        public string UOM { get; set; }
        public string StoringUOM { get; set; }
        public string GDNNo { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
    }

    public class CreateImportTransferToSiteSyncCommandHandler : IRequestHandler<CreateImportTransferToSiteSyncCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IImportTransferToSiteSyncRepository _repository;
        public CreateImportTransferToSiteSyncCommandHandler(IMapper mapper,
            IImportTransferToSiteSyncRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateImportTransferToSiteSyncCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.ImportTransferToSiteSync>(request);
            var rs = await _repository.AddAsync(entity);
            return new Response<int>(rs.Id);
        }
    }
}
