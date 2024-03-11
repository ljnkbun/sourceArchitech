using AutoMapper;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Application.Parameters.ArticleBarcodes;
using Shopfloor.Barcode.Application.Query.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.ArticleBarcodes
{
    public class ArticleBarcodeHistoryProfile : Profile
    {
        public ArticleBarcodeHistoryProfile()
        {

            CreateMap<ArticleBarcodeHistory, ArticleBarcodeHistoryModel>()
                .ReverseMap();
            CreateMap<GetMergeSplitByIdsQuery, ArticleBarcodeHistoryParameter>();
        }

    }
}
