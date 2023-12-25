using AutoMapper;
using Shopfloor.Master.Application.Command.SupplierTypes;
using Shopfloor.Master.Application.Models.SupplierTypes;
using Shopfloor.Master.Application.Parameters.SupplierTypes;
using Shopfloor.Master.Application.Query.SupplierTypes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.SupplierTypes
{
    public class SupplierTypeProfile : Profile
    {
        public SupplierTypeProfile()
        {
            CreateMap<SupplierType, SupplierTypeModel>().ReverseMap();
            CreateMap<CreateSupplierTypeCommand, SupplierType>();
            CreateMap<GetSupplierTypesQuery, SupplierTypeParameter>();
        }
    }
}
