using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingIEDs;
using Shopfloor.IED.Application.Models.WeavingIEDs;
using Shopfloor.IED.Application.Parameters.WeavingIEDs;
using Shopfloor.IED.Application.Query.WeavingIEDs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingIEDs
{
    public class WeavingIEDProfile : Profile
    {
        public WeavingIEDProfile()
        {
            CreateMap<CreateWeavingIEDCommand, WeavingIED>();
            CreateMap<GetWeavingIEDsQuery, WeavingIEDParameter>();
            CreateMap<WeavingIED, WeavingIEDModel>()
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
