using AutoMapper;
using Shopfloor.Master.Application.Command.Genders;
using Shopfloor.Master.Application.Models.Genders;
using Shopfloor.Master.Application.Parameters.Genders;
using Shopfloor.Master.Application.Query.Genders;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderModel>().ReverseMap();
            CreateMap<CreateGenderCommand, Gender>();
            CreateMap<GetGendersQuery, GenderParameter>();
        }
    }
}
