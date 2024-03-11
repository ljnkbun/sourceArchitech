using AutoMapper;

using Shopfloor.Material.Application.Command.BuyerFiles;
using Shopfloor.Material.Application.Models.BuyerFiles;
using Shopfloor.Material.Application.Parameters.BuyerFiles;
using Shopfloor.Material.Application.Query.BuyerFiles;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Application.Mappings
{
    public class BuyerFileProfile : Profile
    {
        public BuyerFileProfile()
        {
            CreateMap<GetBuyerFilesQuery, BuyerFileParameter>();
            CreateMap<CreateBuyerFileCommand, BuyerFile>();
            CreateMap<UpdateBuyerFileCommand, BuyerFile>();
            CreateMap<BuyerFile, BuyerFileModel>().ReverseMap();
        }
    }
}