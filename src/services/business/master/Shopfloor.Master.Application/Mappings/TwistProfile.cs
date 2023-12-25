using AutoMapper;
using Shopfloor.Master.Application.Command.Twists;
using Shopfloor.Master.Application.Models.Twists;
using Shopfloor.Master.Application.Parameters.Twists;
using Shopfloor.Master.Application.Query.Twists;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Twists
{
    public class TwistProfile : Profile
    {
        public TwistProfile()
        {
            CreateMap<Twist, TwistModel>().ReverseMap();
            CreateMap<CreateTwistCommand, Twist>();
            CreateMap<GetTwistsQuery, TwistParameter>();
        }
    }
}
