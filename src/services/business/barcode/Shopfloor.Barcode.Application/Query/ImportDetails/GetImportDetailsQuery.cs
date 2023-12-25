using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.ImportDetails;
using Shopfloor.Barcode.Application.Parameters.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;


namespace Shopfloor.Barcode.Application.Query.ImportDetails
{
    public class GetImportDetailsQuery : IRequest<PagedResponse<IReadOnlyList<ImportDetailModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public int? Id { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public ItemStatus? Status { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
    }
    public class GetImportDetailsQueryHandler : IRequestHandler<GetImportDetailsQuery, PagedResponse<IReadOnlyList<ImportDetailModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IImportDetailRepository _repository;
        public GetImportDetailsQueryHandler(IMapper mapper,
            IImportDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ImportDetailModel>>> Handle(GetImportDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ImportDetailParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ImportDetailParameter.ArticleName), nameof(ImportDetailParameter.ArticleCode) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ImportDetailParameter, ImportDetailModel>(validFilter);
        }
    }
}
