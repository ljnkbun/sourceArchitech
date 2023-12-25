using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportArticles
{
    public class CreateExportArticleCommand : IRequest<Response<int>>
    {
        public int? ExportId { get; set; }
        public int? ArticleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string GDINo { get; set; }
        public ExportTypes? GDIType { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string UOM { get; set; }
        public decimal? Quantity { get; set; }
        public string FromSite { get; set; }
        public string Buyer { get; set; }
        public string SummaryOC { get; set; }
        public string DeliveryOC { get; set; }
        public string LotNo { get; set; }
        public string Note { get; set; }
        public ItemStatus? Status { get; set; }
        public ICollection<CreateExportDetailCommand> ExportDetails { get; set; }
    }

    public class CreateExportArticleEntityCommandHandler : IRequestHandler<CreateExportArticleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportArticleRepository _repository;

        public CreateExportArticleEntityCommandHandler(IMapper mapper,
            IExportArticleRepository repository
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateExportArticleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ExportArticle>(request);
            var rs = await _repository.AddAsync(entity);
            return new Response<int>(rs.Id);
        }
    }
}
