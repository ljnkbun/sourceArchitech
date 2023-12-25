using AutoMapper;
using Shopfloor.Master.Application.Command.CropSeasons;
using Shopfloor.Master.Application.Models.CropSeasons;
using Shopfloor.Master.Application.Parameters.CropSeasons;
using Shopfloor.Master.Application.Query.CropSeasons;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.CropSeasons
{
    public class CropSeasonProfile : Profile
    {
        public CropSeasonProfile()
        {
            CreateMap<CropSeason, CropSeasonModel>().ReverseMap();
            CreateMap<CreateCropSeasonCommand, CropSeason>();
            CreateMap<GetCropSeasonsQuery, CropSeasonParameter>();
        }
    }
}
