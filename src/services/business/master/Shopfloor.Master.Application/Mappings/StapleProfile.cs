using AutoMapper;
using Shopfloor.Master.Application.Command.Staples;
using Shopfloor.Master.Application.Models.Staples;
using Shopfloor.Master.Application.Parameters.Staples;
using Shopfloor.Master.Application.Query.Staples;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Staples
{
    public class StapleProfile : Profile
    {
        public StapleProfile()
        {
            CreateMap<Staple, StapleModel>().ReverseMap();
            CreateMap<CreateStapleCommand, Staple>();
            CreateMap<GetStaplesQuery, StapleParameter>();
        }
    }
}
