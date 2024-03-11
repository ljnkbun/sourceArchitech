using AutoMapper;
using Shopfloor.Master.Application.Command.Suppliers;
using Shopfloor.Master.Application.Models.Suppliers;
using Shopfloor.Master.Application.Parameters.Suppliers;
using Shopfloor.Master.Application.Query.Suppliers;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierModel>().ReverseMap();
            CreateMap<CreateSupplierCommand, Supplier>();
            CreateMap<GetSuppliersQuery, SupplierParameter>();
        }
    }
}
