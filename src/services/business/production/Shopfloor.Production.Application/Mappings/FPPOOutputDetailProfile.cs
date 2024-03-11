using AutoMapper;
using Shopfloor.Production.Application.Command.FPPOOutputDetails;
using Shopfloor.Production.Application.Models.FPPOOutputDetails;
using Shopfloor.Production.Application.Models.FPPOOutputs;
using Shopfloor.Production.Application.Parameters.FPPOOutputDetails;
using Shopfloor.Production.Application.Query.FPPOOutputDetails;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class FPPOOutputDetailProfile : Profile
    {
        public FPPOOutputDetailProfile()
        {
            CreateMap<FPPOOutputDetail, FPPOOutputDetailModel>().ReverseMap();
            CreateMap<FPPOOutputDetail, FPPOOutputToDetailsModel>()
                .ForMember(x=>x.OCNo,s=>s.MapFrom(x=>x.FPPOOutput.OCNo))
                .ForMember(x=>x.PORNo,s=>s.MapFrom(x=>x.FPPOOutput.PORNo))
                .ForMember(x=>x.QCName,s=>s.MapFrom(x=>x.FPPOOutput.QCName))
                .ForMember(x=>x.Start,s=>s.MapFrom(x=>x.FPPOOutput.Start))
                .ForMember(x=>x.ArticleCode,s=>s.MapFrom(x=>x.FPPOOutput.ArticleCode))
                .ForMember(x=>x.ArticleName,s=>s.MapFrom(x=>x.FPPOOutput.ArticleName))
                .ForMember(x=>x.BatchNo,s=>s.MapFrom(x=>x.FPPOOutput.BatchNo))
                .ForMember(x=>x.End,s=>s.MapFrom(x=>x.FPPOOutput.End))
                .ForMember(x=>x.JobOrderNo,s=>s.MapFrom(x=>x.FPPOOutput.JobOrderNo))
                .ForMember(x=>x.FPPOId,s=>s.MapFrom(x=>x.FPPOOutput.FPPOId))
                .ForMember(x=>x.FPPONo,s=>s.MapFrom(x=>x.FPPOOutput.FPPONo))
                .ForMember(x=>x.LineId,s=>s.MapFrom(x=>x.FPPOOutput.LineId))
                .ForMember(x=>x.MachineId,s=>s.MapFrom(x=>x.FPPOOutput.MachineId))
                .ForMember(x=>x.OperationCode,s=>s.MapFrom(x=>x.FPPOOutput.OperationCode))
                .ForMember(x=>x.OperationId,s=>s.MapFrom(x=>x.FPPOOutput.OperationId))
                .ForMember(x=>x.OperationName,s=>s.MapFrom(x=>x.FPPOOutput.OperationName))
                .ForMember(x=>x.PORId,s=>s.MapFrom(x=>x.FPPOOutput.PORId))
                .ForMember(x=>x.ProcessCode,s=>s.MapFrom(x=>x.FPPOOutput.ProcessCode))
                .ForMember(x=>x.ProcessId,s=>s.MapFrom(x=>x.FPPOOutput.ProcessId))
                .ForMember(x=>x.ProcessName,s=>s.MapFrom(x=>x.FPPOOutput.ProcessName))
                .ForMember(x=>x.QCDefinationId,s=>s.MapFrom(x=>x.FPPOOutput.QCDefinationId))
                .ForMember(x=>x.QCName,s=>s.MapFrom(x=>x.FPPOOutput.QCName))
                .ForMember(x=>x.UOM,s=>s.MapFrom(x=>x.FPPOOutput.UOM))
                .ForMember(x=>x.WFXArticleId,s=>s.MapFrom(x=>x.FPPOOutput.WFXArticleId))
                .ReverseMap();
            CreateMap<CreateFPPOOutputDetailCommand, FPPOOutputDetail>();
            CreateMap<GetFPPOOutputDetailsQuery, FPPOOutputDetailParameter>();
        }
    }
}
