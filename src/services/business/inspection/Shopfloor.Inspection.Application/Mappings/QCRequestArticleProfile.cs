using AutoMapper;
using Shopfloor.Inspection.Application.Command.QCRequestArticles;
using Shopfloor.Inspection.Application.Models.QCRequestArticles;
using Shopfloor.Inspection.Application.Models.QCRequests;
using Shopfloor.Inspection.Application.Parameters.QCRequestArticles;
using Shopfloor.Inspection.Application.Query.QCRequestArticles;
using Shopfloor.Inspection.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Shopfloor.Inspection.Application.QCRequestArticles
{
    public class QCRequestArticleProfile : Profile
    {
        public QCRequestArticleProfile()
        {
            CreateMap<QCRequestArticle, QCRequestModel>()
                .ForMember(dest => dest.QCRequestId, opts => opts.MapFrom(src => src.QCRequest.Id))
                .ForMember(dest => dest.QCRequestDate, opts => opts.MapFrom(src => src.QCRequest.QCRequestDate))
                .ForMember(dest => dest.SiteCode, opts => opts.MapFrom(src => src.QCRequest.SiteCode))
                .ForMember(dest => dest.SiteName, opts => opts.MapFrom(src => src.QCRequest.SiteName))
                .ForMember(dest => dest.SupplierName, opts => opts.MapFrom(src => src.QCRequest.SupplierName))
                .ForMember(dest => dest.QCRequestNo, opts => opts.MapFrom(src => src.QCRequest.QCRequestNo))
                .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.QCRequest.Category))
                .ForMember(dest => dest.QCRequestStatus, opts => opts.MapFrom(src => src.QCRequest.QCRequestStatus))
                .ForMember(dest => dest.TransferStatus, opts => opts.MapFrom(src => src.QCRequest.TransferStatus))
                .ForMember(dest => dest.DocumentNo, opts => opts.MapFrom(src => src.QCRequest.DocumentNo))
                .ForMember(dest => dest.QCDefinitionCode, opts => opts.MapFrom(src => src.QCRequest.QCDefinitionCode))
                .ReverseMap();
            CreateMap<QCRequestArticle, QCRequestArticleModel>().ForMember(dest => dest.QCRequest, opts => opts.MapFrom(src => src.QCRequest))
                                                                .ForMember(dest => dest.InpectionResultId, opts => opts.MapFrom<int?>(src =>  GetQCResult(src))).ReverseMap();
            CreateMap<CreateQCRequestArticleCommand, QCRequestArticle>();
            CreateMap<GetQCRequestArticlesQuery, QCRequestArticleParameter>();
        }
        public static int? GetQCResult(QCRequestArticle qCRequestArticle )
        {
            if (qCRequestArticle.Inspection != null)
            {
                return qCRequestArticle.Inspection.Id;
            }
            if (qCRequestArticle.Inpection100PointSys != null)
            {
                return qCRequestArticle.Inpection100PointSys.Id;
            }
            if (qCRequestArticle.Inpection4PointSys != null)
            {
                return qCRequestArticle.Inpection4PointSys.Id;
            }
            if (qCRequestArticle.InpectionTCStandard != null)
            {
                return qCRequestArticle.InpectionTCStandard.Id;
            }
            return 0;
        }
    }
}
