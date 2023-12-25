using AutoMapper;

using Shopfloor.Material.Application.Command.Suppliers;
using Shopfloor.Material.Application.Models.SupplierProductCategory;
using Shopfloor.Material.Application.Models.Suppliers;
using Shopfloor.Material.Application.Parameters.Suppliers;
using Shopfloor.Material.Application.Query.Suppliers;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Application.Mappings
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierModel>().ReverseMap();
            CreateMap<GetSuppliersQuery, SupplierParameter>().ReverseMap();
            CreateMap<UpdateSupplierCommand, Supplier>().ReverseMap();
            CreateMap<CreateSupplierCommand, Supplier>().ReverseMap();
            CreateMap<SupplierProductCategoryModel, SupplierProductCategory>().ReverseMap();
            CreateMap<SupplierImportExcelModel, Supplier>().ReverseMap();
        }
    }
}