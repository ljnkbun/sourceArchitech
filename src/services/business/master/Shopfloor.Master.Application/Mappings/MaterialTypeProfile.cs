using AutoMapper;
using Shopfloor.Master.Application.Command.MaterialTypes;
using Shopfloor.Master.Application.Models.MaterialTypes;
using Shopfloor.Master.Application.Parameters.MaterialTypes;
using Shopfloor.Master.Application.Query.MaterialTypes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            CreateMap<MaterialType, MaterialTypeModel>();
            CreateMap<CreateMaterialTypeCommand, MaterialType>();
            CreateMap<UpdateMaterialTypeCommand, MaterialType>().ForMember(x => x.CategoryMapMaterialTypes, opt => opt.Ignore());
            CreateMap<GetMaterialTypesQuery, MaterialTypeParameter>();
        }
    }
}
