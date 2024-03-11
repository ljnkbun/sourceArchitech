using AutoMapper;
using Shopfloor.Production.Application.Command.FPPOOutputs;
using Shopfloor.Production.Application.Models.FPPOOutputs;
using Shopfloor.Production.Application.Parameters.FPPOOutputs;
using Shopfloor.Production.Application.Query.FPPOOutputs;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class FPPOOutputProfile : Profile
    {
        public FPPOOutputProfile()
        {
            CreateMap<FPPOOutput, FPPOOutputModel>().ReverseMap();
            CreateMap<CreateFPPOOutputCommand, FPPOOutput>();
            CreateMap<GetFPPOOutputsQuery, FPPOOutputParameter>();
            CreateMap<GetFPPOOutputToDetailsQuery, FPPOOutputToDetailsParameter>();
        }
    }
}
