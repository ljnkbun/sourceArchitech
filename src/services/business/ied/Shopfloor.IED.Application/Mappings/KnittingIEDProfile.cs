using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingIEDs;
using Shopfloor.IED.Application.Models.KnittingIEDs;
using Shopfloor.IED.Application.Parameters.KnittingIEDs;
using Shopfloor.IED.Application.Query.KnittingIEDs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingIEDs
{
    public class KnittingIEDProfile : Profile
    {
        public KnittingIEDProfile()
        {
            CreateMap<CreateKnittingIEDCommand, KnittingIED>();
            CreateMap<GetKnittingIEDsQuery, KnittingIEDParameter>();
            CreateMap<KnittingIED, KnittingIEDModel>()
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
