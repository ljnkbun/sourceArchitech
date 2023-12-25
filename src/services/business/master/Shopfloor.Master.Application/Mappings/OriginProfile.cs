using AutoMapper;
using Shopfloor.Master.Application.Command.Origins;
using Shopfloor.Master.Application.Models.Origins;
using Shopfloor.Master.Application.Parameters.Origins;
using Shopfloor.Master.Application.Query.Origins;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Origins
{
    public class OriginProfile : Profile
    {
        public OriginProfile()
        {
            CreateMap<Origin, OriginModel>().ReverseMap();
            CreateMap<CreateOriginCommand, Origin>();
            CreateMap<GetOriginsQuery, OriginParameter>();
        }
    }
}
