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
            CreateMap<ArticleBarcode, ArticleBarcodeModel>()
                .ForMember(x => x.FromId, s => s.MapFrom(p => ConvertStringToIntArr(p.FromId)))
                .ForMember(x => x.ToId, s => s.MapFrom(p => ConvertStringToIntArr(p.ToId)))
                .ReverseMap();
            CreateMap<ArticleBarcode, ExportDetail>().ReverseMap();
            CreateMap<ArticleBarcode, EventBus.Models.Responses.Barcodes.ArticleBarcodeModel>().ReverseMap();
            CreateMap<SplitDetailModel, ArticleBarcode>().ReverseMap();
            CreateMap<CreateArticleBarcodeCommand, ArticleBarcode>();
            CreateMap<GetArticleBarcodesQuery, ArticleBarcodeParameter>();
        }

        private static int[] ConvertStringToIntArr(string s)
        {
            if (s == null || string.IsNullOrEmpty(s)) return null;
            var arrStr = s.Split(',');
            if (!arrStr.Any()) return null;
            return arrStr.Select(x => int.Parse(string.IsNullOrEmpty(x.Trim()) ? "0" : x.Trim())).ToArray();
        }
    }
}
