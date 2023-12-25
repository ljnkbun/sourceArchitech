using AutoMapper;
using Shopfloor.Barcode.Application.Command.ArticleBarcodes;
using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Application.Parameters.ArticleBarcodes;
using Shopfloor.Barcode.Application.Query.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.ArticleBarcodes
{
    public class ArticleBarcodeProfile : Profile
    {
        public ArticleBarcodeProfile()
        {
            CreateMap<ArticleBarcode, ArticleBarcodeModel>().ReverseMap();
            CreateMap<SplitDetailModel, ArticleBarcode>().ReverseMap();
            CreateMap<CreateArticleBarcodeCommand, ArticleBarcode>();
            CreateMap<GetArticleBarcodesQuery, ArticleBarcodeParameter>();
        }
    }
}
