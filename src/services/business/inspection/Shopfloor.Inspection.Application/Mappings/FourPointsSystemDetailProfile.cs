using AutoMapper;
using Shopfloor.Inspection.Application.Command.FourPointsSystemDetails;
using Shopfloor.Inspection.Application.Models.FourPointsSystemDetails;
using Shopfloor.Inspection.Application.Parameters.FourPointsSystemDetails;
using Shopfloor.Inspection.Application.Query.FourPointsSystemDetails;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.FourPointsSystemDetails
{
    public class FourPointsSystemDetailProfile : Profile
    {
        public FourPointsSystemDetailProfile()
        {
            CreateMap<FourPointsSystemDetail, FourPointsSystemDetailModel>().ReverseMap();
            CreateMap<CreateFourPointsSystemDetailCommand, FourPointsSystemDetail>();
            CreateMap<GetFourPointsSystemDetailsQuery, FourPointsSystemDetailParameter>();
        }
    }
}
