using AutoMapper;
using Shopfloor.Master.Application.Command.ColorCards;
using Shopfloor.Master.Application.Models.ColorCards;
using Shopfloor.Master.Application.Parameters.ColorCards;
using Shopfloor.Master.Application.Query.ColorCards;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ColorCardProfile : Profile
    {
        public ColorCardProfile()
        {
            CreateMap<ColorCard, ColorCardModel>().ReverseMap();
            CreateMap<CreateColorCardCommand, ColorCard>();
            CreateMap<GetColorCardsQuery, ColorCardParameter>();
        }
    }
}
