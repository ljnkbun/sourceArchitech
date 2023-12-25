using AutoMapper;

using Shopfloor.Material.Application.Command.PriceLists;
using Shopfloor.Material.Application.Models.PriceListDetailColors;
using Shopfloor.Material.Application.Models.PriceListDetails;
using Shopfloor.Material.Application.Models.PriceListDetailSizes;
using Shopfloor.Material.Application.Models.PriceLists;
using Shopfloor.Material.Application.Parameters.PriceLists;
using Shopfloor.Material.Application.Query.PriceLists;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Application.Mappings
{
    public class PriceListProfile : Profile
    {
        public PriceListProfile()
        {
            CreateMap<PriceList, PriceListModel>().ReverseMap();
            CreateMap<GetPriceListsQuery, PriceListParameter>().ReverseMap();
            CreateMap<CreatePriceListCommand, PriceList>().ReverseMap();
            CreateMap<UpdatePriceListCommand, PriceList>().ReverseMap();
            CreateMap<PriceListImportExcelModel, PriceList>().ReverseMap();
            CreateMap<DataPriceListCreate, PriceList>().ReverseMap();
            CreateMap<PriceListDetail, PriceListDetailModel>().ReverseMap();
            CreateMap<PriceListDetailColor, PriceListDetailColorModel>().ReverseMap();
            CreateMap<PriceListDetailSize, PriceListDetailSizeModel>().ReverseMap();
        }
    }
}