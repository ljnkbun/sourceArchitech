using AutoMapper;

using Shopfloor.Material.Application.Command.SupplierFiles;
using Shopfloor.Material.Application.Models.SupplierFiles;
using Shopfloor.Material.Application.Parameters.SupplierFiles;
using Shopfloor.Material.Application.Query.SupplierFiles;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Application.Mappings
{
    public class SupplierFileProfile : Profile
    {
        public SupplierFileProfile()
        {
            CreateMap<GetSupplierFilesQuery, SupplierFileParameter>();
            CreateMap<CreateSupplierFileCommand, SupplierFile>();
            CreateMap<UpdateSupplierFileCommand, SupplierFile>();
            CreateMap<SupplierFile, SupplierFileModel>().ReverseMap();
        }
    }
}