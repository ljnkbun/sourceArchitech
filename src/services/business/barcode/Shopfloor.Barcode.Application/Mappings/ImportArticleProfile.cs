using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Application.Models.ImportArticles;
using Shopfloor.Barcode.Application.Models.WfxImportSyncs;
using Shopfloor.Barcode.Application.Models.WfxPOArticles;
using Shopfloor.Barcode.Application.Parameters.ImportArticles;
using Shopfloor.Barcode.Application.Parameters.WfxImportSyncs;
using Shopfloor.Barcode.Application.Query.ImportArticles;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ImportArticleProfile : Profile
    {
        public ImportArticleProfile()
        {
            CreateMap<ImportArticle, ImportArticleModel>()
                .ForMember(x => x.ImportDetailModels, d => d.MapFrom(o => o.ImportDetails))
                .ReverseMap();
            CreateMap<ImportArticleModel, WfxPOArticleParentModel>().ReverseMap();
            CreateMap<CreateImportArticleCommand, ImportArticle>();
            CreateMap<GetImportArticlesQuery, ImportArticleParameter>();
            CreateMap<UpdateImportArticleCommand, ImportArticle>()
                .ForMember(x => x.ImportDetails, opt => opt.Condition(source => source.EntityState == EntityState.Added))
                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.EntityState == EntityState.Deleted || source.EntityState == EntityState.Modified))
                .ForMember(dest => dest.ImportId, opt => opt.Condition(source => source.EntityState == EntityState.Added));

            CreateMap<ImportArticle, WfxImportSyncModel>()
                .ForMember(dest => dest.ReceiptDocumentID, opts => opts.MapFrom(src => src.Import.Code))
                .ForMember(dest => dest.OrderRefNum, opts => opts.MapFrom(src => src.OrderRefNum))
                .ForMember(dest => dest.SupplierName, opts => opts.MapFrom(src => src.SupplierName))
                .ForMember(dest => dest.WFXArticleCode, opts => opts.MapFrom(src => src.ArticleCode))
                .ForMember(dest => dest.ColorCode, opts => opts.MapFrom(src => src.ColorCode))
                .ForMember(dest => dest.SizeCode, opts => opts.MapFrom(src => src.SizeCode))
                .ForMember(dest => dest.ListRoll, opts => opts.MapFrom(src => src.ImportDetails.Select(roll => new Models.WfxImportSyncs.Roll()
                {
                    ColorCode = roll.Color,
                    MovementUOM = roll.ArticleBarcode.BarcodeUOM,
                    POUOM = roll.ArticleBarcode.ArticleUOM,
                    ReceiptRoll = roll.ArticleBarcode.RemainQuantity,
                    ReceiptRollBarcode = roll.ArticleBarcode.Barcode,
                    ReceiptRollID = string.Empty,
                    ReceiptRollNo = roll.Unit,
                    ReceiptRollNotes = roll.Note,
                    ReceiptRollShadeRef = roll.Shade,
                    ReceiptRollSORef = string.Empty,
                    SizeCode = roll.Size,
                    SupplierShade = roll.Shade,
                    TotalRoll = roll.Quantity,
                    TotalReceiptRoll = roll.ArticleBarcode.RemainQuantity,
                    UpdateDate = DateTime.Now,
                })));

            CreateMap<Models.WfxImportSyncs.Roll, EventBus.Models.Responses.Roll>();
            CreateMap<WfxImportSyncModel, GetWfxImportSyncData>();
            CreateMap<GetWfxImportSyncParameter, WfxImportSyncParameter>();
        }
    }

}
