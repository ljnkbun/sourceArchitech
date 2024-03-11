using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.Imports;
using Shopfloor.Barcode.Application.Parameters.Imports;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;


namespace Shopfloor.Barcode.Application.Query.Imports
{
    public class GetImportsQuery : IRequest<PagedResponse<IReadOnlyList<ImportModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Types { get; set; }
        public string Statuses { get; set; }
        public string PONo { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string WfxStatuses { get;set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetImportsQueryHandler : IRequestHandler<GetImportsQuery, PagedResponse<IReadOnlyList<ImportModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IImportRepository _repository;
        private readonly IImportArticleRepository _articleRepository;

        public GetImportsQueryHandler(IMapper mapper,
            IImportRepository repository
            , IImportArticleRepository articleRepository
            )
        {
            _mapper = mapper;
            _repository = repository;
            _articleRepository = articleRepository;
        }

        public async Task<PagedResponse<IReadOnlyList<ImportModel>>> Handle(GetImportsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ImportParameter>(request);
            ImportType[] importTypes = null;
            ImportStatus[] statuses = null;
            WfxStatus[] wfxStatuses = null;

            if (!string.IsNullOrEmpty(request.Types))
            {
                importTypes = request.Types.Split(',').Select(x => (ImportType)Enum.Parse(typeof(ImportType), x)).ToArray();
            }

            if (!string.IsNullOrEmpty(request.Statuses))
            {
                statuses = request.Statuses.Split(',').Select(x => (ImportStatus)Enum.Parse(typeof(ImportStatus), x)).ToArray();
            }

            if(!string.IsNullOrEmpty(request.WfxStatuses))
            {
                wfxStatuses = request.WfxStatuses.Split(',').Select(x => (WfxStatus)Enum.Parse(typeof(WfxStatus), x)).ToArray();
            }

            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;

            var rs = await _repository.GetModelPagedCustomReponseAsync<ImportParameter, ImportModel>(validFilter, statuses, importTypes, request.ArticleCode, request.ArticleName, request.PONo, wfxStatuses);

            var articles = await _articleRepository.GetImportArticleByImportIds(rs.Data.Select(x => x.Id).ToArray());

            foreach (var r in rs.Data)
            {
                r.ImportArticleModels = null;
            }

            return rs;
        }
    }
}
