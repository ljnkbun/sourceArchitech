using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ArticleBarcodes
{
    public class CreateArticleBarcodeCommand : IRequest<Response<int>>
    {
        public string Barcode { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RemainQuantity { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Site { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string GroupCode { get; set; }
        public string Note { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? PreLocationId { get; set; }
    }
    public class CreateArticleBarcodeCommandHandler : IRequestHandler<CreateArticleBarcodeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleBarcodeRepository _repository;
        public CreateArticleBarcodeCommandHandler(IMapper mapper,
            IArticleBarcodeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateArticleBarcodeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ArticleBarcode>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
