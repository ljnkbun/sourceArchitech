using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class CreateExportDetailCommand : IRequest<Response<int>>
    {
        public ItemStatus? Status { get; set; }

        public string Name { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public int? ExportArticleId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string Shade { get; set; }
        public string Grade { get; set; }
        public string OC { get; set; }
        public string UOM { get; set; }
        public string FPPOOCNUm { get; set; }
        public string BuyerStyleRef { get; set; }
        public string No { get; set; }
        public string Barcode { get; set; }
        public string ParentBarcode { get; set; }
        public string OCRefNum { get; set; }
        public string LotNo { get; set; }
        public string Location { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public decimal? RemainQuantity { get; set; }
        public decimal? WeightPerCone { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? Quantity { get; set; }
        public string Note { get; set; }
        public EntityState? EntityState { get; internal set; }
    }

    public class CreateExportDetailEntityCommandHandler : IRequestHandler<CreateExportDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IExportDetailRepository _repository;

        public CreateExportDetailEntityCommandHandler(IMapper mapper,
            IExportDetailRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateExportDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ExportDetail>(request);
            var rs = await _repository.AddAsync(entity);
            return new Response<int>(rs.Id);
        }
    }
}
