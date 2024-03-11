using AutoMapper;
using Shopfloor.Planning.Application.Command.FPPOs;
using Shopfloor.Planning.Application.Models.FPPOs;
using Shopfloor.Planning.Application.Parameters.FPPOs;
using Shopfloor.Planning.Application.Query.FPPOs;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Mappings
{
    public class FPPOProfile : Profile
    {
        public FPPOProfile()
        {
            CreateMap<FPPO, FPPOModel>().ReverseMap();
            CreateMap<CreateFPPOCommand, FPPO>();
            CreateMap<GetFPPOsQuery, FPPOParameter>();
        }
    }
}
