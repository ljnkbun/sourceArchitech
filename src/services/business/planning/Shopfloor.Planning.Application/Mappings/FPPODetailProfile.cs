using AutoMapper;
using Shopfloor.Planning.Application.Command.FPPODetails;
using Shopfloor.Planning.Application.Models.FPPODetails;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Mappings
{
    public class FPPODetailProfile : Profile
    {
        public FPPODetailProfile()
        {
            CreateMap<FPPODetail, FPPODetailModel>().ReverseMap();
            CreateMap<CreateFPPODetailCommand, FPPODetail>();
            CreateMap<UpdateFPPODetailCommand, FPPODetail>();
        }
    }
}
