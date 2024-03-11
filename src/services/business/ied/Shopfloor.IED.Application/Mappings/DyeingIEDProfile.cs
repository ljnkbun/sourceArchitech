using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingIEDs;
using Shopfloor.IED.Application.Models.DyeingIEDs;
using Shopfloor.IED.Application.Parameters.DyeingIEDs;
using Shopfloor.IED.Application.Query.DyeingIEDs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingIEDProfile : Profile
    {
        public DyeingIEDProfile()
        {
            CreateMap<CreateDyeingIEDCommand, DyeingIED>();
            CreateMap<GetDyeingIEDsQuery, DyeingIEDParameter>();
            CreateMap<GetSearchDyeingIEDsQuery, SearchDyeingIEDParameter>();
            CreateMap<DyeingIED, SearchDyeingIEDModel>()
                .ForMember(dest => dest.RequestType,
                    otp => otp.MapFrom(x =>
                        x.RequestArticleOutput.RequestDivisionProcess.RequestDivision.Request.RequestTypeId))
                .ForMember(dest => dest.RecipeNo, otp => otp.MapFrom(x => x.Recipe.RecipeNo));
            CreateMap<DyeingIED, DyeingIEDModel>()
                .ForMember(dest => dest.RequestType,
                    otp => otp.MapFrom(x =>
                        x.RequestArticleOutput.RequestDivisionProcess.RequestDivision.Request.RequestType.Name))
				.ForMember(dest => dest.ExpectedDate,
					otp => otp.MapFrom(x =>
						x.RequestArticleOutput.RequestDivisionProcess.RequestDivision.ExpectedDate))
                .ForMember(dest => dest.ExpectedQty,
                    otp => otp.MapFrom(x =>
                        x.RequestArticleOutput.RequestDivisionProcess.RequestDivision.Request.ExpectedQty));
        }
    }
}