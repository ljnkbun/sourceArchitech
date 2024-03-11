using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.Exports;
using Shopfloor.Barcode.Application.Parameters.Exports;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.Exports
{
    public class GetExportsQuery : IRequest<PagedResponse<IReadOnlyList<ExportModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Types { get; set; }
        public string Statuses { get; set; }
        public string WfxStatuses { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }
    public class GetExportEntitiesQueryHandler : IRequestHandler<GetExportsQuery, PagedResponse<IReadOnlyList<ExportModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IExportRepository _repository;
        private readonly IExportArticleRepository _articleRepository;

        public GetExportEntitiesQueryHandler(IMapper mapper,
            IExportRepository repository
            , IExportArticleRepository articleRepository
            )
        {
            _mapper = mapper;
            _repository = repository;
            _articleRepository = articleRepository;
        }

        public async Task<PagedResponse<IReadOnlyList<ExportModel>>> Handle(GetExportsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ExportParameter>(request);
            ExportTypes[] exportTypes = null;
            ExportStatus[] statuses = null;
            WfxStatus[] wfxStatuses = null;

            if (!string.IsNullOrEmpty(request.Types))
            {
                exportTypes = request.Types.Split(',').Select(x => (ExportTypes)Enum.Parse(typeof(ExportTypes), x)).ToArray();
            }

            if (!string.IsNullOrEmpty(request.WfxStatuses))
            {
                wfxStatuses = request.WfxStatuses.Split(',').Select(x => (WfxStatus)Enum.Parse(typeof(WfxStatus), x)).ToArray();
            }

            if (!string.IsNullOrEmpty(request.Statuses))
            {
                statuses = request.Statuses.Split(',').Select(x => (ExportStatus)Enum.Parse(typeof(ExportStatus), x)).ToArray();
            }
            validFilter.OrderBy = string.IsNullOrEmpty(validFilter.OrderBy) ? " ModifiedDate DESC " : validFilter.OrderBy;

            var rs = await _repository.GetModelPagedCustomReponseAsync<ExportParameter, ExportModel>(validFilter, statuses, exportTypes, wfxStatuses);


            var articles = await _articleRepository.GetExportArticleByExportIds(rs.Data.Select(x => x.Id).ToArray());

            foreach (var r in rs.Data)
            {
                var lst = articles.Where(x => x.ExportId == r.Id);
                r.GDINo = string.Join(", ", lst.Select(x => x.GDINum));
                r.ArticleCode = string.Join(", ", lst.Select(x => x.ArticleCode));
                r.ArticleName = string.Join(", ", lst.Select(x => x.ArticleName));
                r.Buyer = string.Join(", ", lst.Select(x => x.Buyer));
                r.ExportArticleModels = null;
            }

            return rs;
        }
    }
}
