using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.Exports;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.Exports
{
    public class GetExportQuery : IRequest<Response<ExportModel>>
    {
        public int Id { get; set; }
    }
    public class GetExportEntityQueryHandler : IRequestHandler<GetExportQuery, Response<ExportModel>>
    {
        private readonly IMapper _mapper;
        private readonly IExportRepository _repository;
        private readonly IWfxGDIRepository _articleRepository;

        public GetExportEntityQueryHandler(IMapper mapper,
            IExportRepository repository
            , IWfxGDIRepository articleRepository
            )
        {
            _mapper = mapper;
            _repository = repository;
            _articleRepository = articleRepository;
        }

        public async Task<Response<ExportModel>> Handle(GetExportQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetExportByIdAsync(query.Id);
            if (entity == null) return new($"Export Not Found (Id:{query.Id}).");
            var rs = _mapper.Map<ExportModel>(entity);

            var artcile = rs.ExportArticleModels.FirstOrDefault();
            rs.GDINo = artcile?.GDINum;
            rs.ArticleCode = artcile?.ArticleCode;
            rs.ArticleName = artcile?.ArticleName;
            rs.Buyer = artcile?.Buyer;

            return new Response<ExportModel>(rs);
        }
    }
}
