using AutoMapper;
using Shopfloor.Planning.Application.Command.StripFactoryDetails;
using Shopfloor.Planning.Application.Command.StripFactorySchedules;
using Shopfloor.Planning.Application.Models.Articles;
using Shopfloor.Planning.Application.Models.StripFactorySchedules;
using Shopfloor.Planning.Application.Parameters.StripFactorySchedules;
using Shopfloor.Planning.Application.Query.StripFactorySchedules;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.StripFactorySchedules
{
    public class StripFactoryScheduleProfile : Profile
    {
        public StripFactoryScheduleProfile()
        {
            CreateMap<StripFactorySchedule, StripFactoryScheduleModel>().ReverseMap();
            CreateMap<StripFactoryScheduleModel, CalculateStripFactoryScheduleModel>().ReverseMap();
            CreateMap<CalculateStripFactoryScheduleModel, StripFactoryScheduleModel>().ReverseMap();
            CreateMap<CreateStripFactoryScheduleCommand, StripFactorySchedule>();
            CreateMap<UpdateStripFactoryScheduleCommand, StripFactorySchedule>();
            CreateMap<GetStripFactorySchedulesQuery, StripFactoryScheduleParameter>();
            CreateMap<StripFactorySchedule, ArticleHistoryModel>()
               .ForMember(dest => dest.LineId, opts => opts.MapFrom(src => src.StripSchedule.LineId))
               .ForMember(dest => dest.MachineId, opts => opts.MapFrom(src => src.StripSchedule.MachineId))
               .ForMember(dest => dest.FromDate, opts => opts.MapFrom(src => src.StripSchedule.FromDate))
               .ForMember(dest => dest.ToDate, opts => opts.MapFrom(src => src.StripSchedule.ToDate))
               .ForMember(dest => dest.ReceivedCapacity, opts => opts.MapFrom(src => src.StripSchedule.StripSchedulePlanningDetails.Sum(x => x.ReceivedCapacity)))
               .ForMember(dest => dest.StripFactoryId, opts => opts.MapFrom(src => src.StripFactoryId))
               .ForMember(dest => dest.OCNo, opts => opts.MapFrom(src => src.StripFactory.Por.OCNo))
               .ForMember(dest => dest.DeliveryDate, opts => opts.MapFrom(src => src.StripFactory.Por.DeliveryDate))
               .ForMember(dest => dest.PORNo, opts => opts.MapFrom(src => src.StripFactory.Por.PORNo))
               .ForMember(dest => dest.DivisionName, opts => opts.MapFrom(src => src.StripFactory.Por.DivisionName))
               .ForMember(dest => dest.ArticleName, opts => opts.MapFrom(src => src.StripFactory.Por.ArticleName))
               .ForMember(dest => dest.ArticleCode, opts => opts.MapFrom(src => src.StripFactory.Por.ArticleCode))
               .ForMember(dest => dest.Buyer, opts => opts.MapFrom(src => src.StripFactory.Por.Buyer))
               .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.StripFactory.Por.Category))
               .ForMember(dest => dest.SubCategory, opts => opts.MapFrom(src => src.StripFactory.Por.SubCategory))
               .ForMember(dest => dest.ProductGroup, opts => opts.MapFrom(src => src.StripFactory.Por.ProductGroup))
               .ForMember(dest => dest.BOMNo, opts => opts.MapFrom(src => src.StripFactory.Por.BOMNo))
               .ForMember(dest => dest.ProcessName, opts => opts.MapFrom(src => src.StripFactory.Por.ProcessName))
               .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.StripFactory.Por.Quantity))
               .ForMember(dest => dest.RemainingQuantity, opts => opts.MapFrom(src => src.StripFactory.Por.RemainingQuantity))
               .ForMember(dest => dest.PlanningGroupFactoryId, opts => opts.MapFrom(src => src.StripFactory.PlanningGroupFactoryId))
               .ReverseMap();

            CreateMap<CreateStripFactoryDetailCommand, StripFactoryScheduleDetail>()
                        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.RemainingQuantity));
        }
    }
}
