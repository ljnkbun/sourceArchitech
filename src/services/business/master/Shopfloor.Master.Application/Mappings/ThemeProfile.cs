using AutoMapper;
using Shopfloor.Master.Application.Command.Themes;
using Shopfloor.Master.Application.Models.Themes;
using Shopfloor.Master.Application.Parameters.Themes;
using Shopfloor.Master.Application.Query.Themes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ThemeProfile : Profile
    {
        public ThemeProfile()
        {
            CreateMap<Theme, ThemeModel>().ReverseMap();
            CreateMap<CreateThemeCommand, Theme>();
            CreateMap<GetThemesQuery, ThemeParameter>();
        }
    }
}
