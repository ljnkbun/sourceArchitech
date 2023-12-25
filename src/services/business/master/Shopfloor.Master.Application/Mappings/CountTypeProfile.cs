using AutoMapper;
using Shopfloor.Master.Application.Command.CountTypes;
using Shopfloor.Master.Application.Models.CountTypes;
using Shopfloor.Master.Application.Parameters.CountTypes;
using Shopfloor.Master.Application.Query.CountTypes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.CountTypes
{
    public class CountTypeProfile : Profile
    {
        public CountTypeProfile()
        {
            CreateMap<CountType, CountTypeModel>().ReverseMap();
            CreateMap<CreateCountTypeCommand, CountType>();
            CreateMap<GetCountTypesQuery, CountTypeParameter>();
        }
    }
}
