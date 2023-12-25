using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ImportTransferToSiteSyncs;
using Shopfloor.Barcode.Application.Parameters.ImportTransferToSiteSyncs;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;


namespace Shopfloor.Barcode.Application.Query.ImportTransferToSiteSyncs
{
    public class GetImportTransferToSiteSyncsQuery : IRequest<PagedResponse<IReadOnlyList<ImportTransferToSiteSyncModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public int? Id { get; set; }
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
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetImportTransferToSiteSyncsQueryHandler : IRequestHandler<GetImportTransferToSiteSyncsQuery, PagedResponse<IReadOnlyList<ImportTransferToSiteSyncModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IImportTransferToSiteSyncRepository _repository;
        public GetImportTransferToSiteSyncsQueryHandler(IMapper mapper,
            IImportTransferToSiteSyncRepository repository)
        {
            _mapper = mapper; 
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ImportTransferToSiteSyncModel>>> Handle(GetImportTransferToSiteSyncsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ImportTransferToSiteSyncParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ImportTransferToSiteSync.GDNNo) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ImportTransferToSiteSyncParameter, ImportTransferToSiteSyncModel>(validFilter);
        }
    }
}
