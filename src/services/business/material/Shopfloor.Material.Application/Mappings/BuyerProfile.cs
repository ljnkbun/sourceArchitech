using AutoMapper;

using Shopfloor.Material.Application.Command.Buyers;
using Shopfloor.Material.Application.Models.Buyers;
using Shopfloor.Material.Application.Parameters.Buyers;
using Shopfloor.Material.Application.Query.Buyers;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Application.Mappings
{
    public class BuyerProfile : Profile
    {
        public BuyerProfile()
        {
            CreateMap<Buyer, BuyerModel>().ReverseMap();
            CreateMap<BuyerProductCategory, BuyerProductCategoryModel>().ReverseMap();
            CreateMap<CreateBuyerCommand, Buyer>().ReverseMap();
            CreateMap<GetBuyersQuery, BuyerParameter>().ReverseMap();
            CreateMap<BuyerImportExcelModel, CreateBuyerCommand>().ReverseMap();
            CreateMap<GetCodeNameBuyersQuery, BuyerParameter>().ReverseMap();
            CreateMap<Buyer, BuyerDropdownModel>().ReverseMap();
            CreateMap<BuyerImportExcelModel, Buyer>().ReverseMap();
        }
    }
}