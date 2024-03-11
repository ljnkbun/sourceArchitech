using AutoMapper;
using Shopfloor.Inspection.Application.Command.OneHundredPointSystemDetails;
using Shopfloor.Inspection.Application.Models.OneHundredPointSystemDetails;
using Shopfloor.Inspection.Application.Parameters.OneHundredPointSystemDetails;
using Shopfloor.Inspection.Application.Query.OneHundredPointSystemDetails;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.OneHundredPointSystemDetails
{
    public class OneHundredPointSystemDetailProfile : Profile
    {
        public OneHundredPointSystemDetailProfile()
        {
            CreateMap<OneHundredPointSystemDetail, OneHundredPointSystemDetailModel>().ReverseMap();
            CreateMap<CreateOneHundredPointSystemDetailCommand, OneHundredPointSystemDetail>();
            CreateMap<GetOneHundredPointSystemDetailsQuery, OneHundredPointSystemDetailParameter>();
        }
    }
}
