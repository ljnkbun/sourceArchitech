using AutoMapper;
using Shopfloor.Master.Application.Command.ProductGroups;
using Shopfloor.Master.Application.Models.ProductGroups;
using Shopfloor.Master.Application.Parameters.ProductGroups;
using Shopfloor.Master.Application.Query.ProductGroups;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ProductGroupProfile : Profile
    {
        public ProductGroupProfile()
        {
            CreateMap<ProductGroup, ProductGroupModel>();
            CreateMap<CreateProductGroupCommand, ProductGroup>();
            CreateMap<UpdateProductGroupCommand, ProductGroup>().ForMember(x => x.MaterialTypeMapProductGroups, opt => opt.Ignore());
            CreateMap<GetProductGroupsQuery, ProductGroupParameter>();
        }
    }
}
