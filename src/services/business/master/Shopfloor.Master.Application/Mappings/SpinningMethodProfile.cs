using AutoMapper;
using Shopfloor.Master.Application.Command.SpinningMethods;
using Shopfloor.Master.Application.Models.SpinningMethods;
using Shopfloor.Master.Application.Parameters.SpinningMethods;
using Shopfloor.Master.Application.Query.SpinningMethods;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.SpinningMethods
{
    public class SpinningMethodProfile : Profile
    {
        public SpinningMethodProfile()
        {
            CreateMap<SpinningMethod, SpinningMethodModel>().ReverseMap();
            CreateMap<CreateSpinningMethodCommand, SpinningMethod>();
            CreateMap<GetSpinningMethodsQuery, SpinningMethodParameter>();
        }
    }
}
