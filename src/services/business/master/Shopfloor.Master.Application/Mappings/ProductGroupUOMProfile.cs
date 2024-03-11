using AutoMapper;
using Shopfloor.Master.Application.Command.ProductGroupUOMs;
using Shopfloor.Master.Application.Models.ProductGroupUOMs;
using Shopfloor.Master.Application.Parameters.ProductGroupUOMs;
using Shopfloor.Master.Application.Query.ProductGroupUOMs;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.ProductGroupUOMs
{
    public class ProductGroupUOMProfile : Profile
    {
        public ProductGroupUOMProfile()
        {
            CreateMap<ProductGroupUOM, ProductGroupUOMModel>().ReverseMap();
            CreateMap<CreateProductGroupUOMCommand, ProductGroupUOM>();
            CreateMap<UpdateProductGroupUOMCommand, ProductGroupUOM>();
            CreateMap<GetProductGroupUOMsQuery, ProductGroupUOMParameter>();
        }
    }
}