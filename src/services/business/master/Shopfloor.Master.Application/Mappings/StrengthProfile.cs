using AutoMapper;
using Shopfloor.Master.Application.Command.Strengths;
using Shopfloor.Master.Application.Models.Strengths;
using Shopfloor.Master.Application.Parameters.Strengths;
using Shopfloor.Master.Application.Query.Strengths;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Strengths
{
    public class StrengthProfile : Profile
    {
        public StrengthProfile()
        {
            CreateMap<Strength, StrengthModel>().ReverseMap();
            CreateMap<CreateStrengthCommand, Strength>();
            CreateMap<GetStrengthsQuery, StrengthParameter>();
        }
    }
}
