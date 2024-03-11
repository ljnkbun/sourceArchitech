using AutoMapper;
using Shopfloor.IED.Application.Command.SewingIEDs;
using Shopfloor.IED.Application.Models.SewingIEDs;
using Shopfloor.IED.Application.Parameters.SewingIEDs;
using Shopfloor.IED.Application.Query.SewingIEDs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingIEDs
{
    public class SewingIEDProfile : Profile
    {
        public SewingIEDProfile()
        {
            CreateMap<CreateSewingIEDCommand, SewingIED>();
            CreateMap<GetSewingIEDsQuery, SewingIEDParameter>();
            CreateMap<SewingIED, SewingIEDModel>()
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
