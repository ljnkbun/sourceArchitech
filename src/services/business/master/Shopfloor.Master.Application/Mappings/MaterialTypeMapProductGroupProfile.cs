using AutoMapper;
using Shopfloor.Master.Application.Command.MaterialTypeMapProductGroups;
using Shopfloor.Master.Application.Models.MaterialTypeMapProductGroups;
using Shopfloor.Master.Application.Parameters.MaterialTypeMapProductGroups;
using Shopfloor.Master.Application.Query.MaterialTypeMapProductGroups;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.MaterialTypeMapProductGroups
{
    public class MaterialTypeMapProductGroupProfile : Profile
    {
        public MaterialTypeMapProductGroupProfile()
        {
            CreateMap<MaterialTypeMapProductGroup, MaterialTypeMapProductGroupModel>().ReverseMap();
            CreateMap<MapProductGroupToMaterialTypeModel, MaterialTypeMapProductGroup>().ReverseMap();
            CreateMap<CreateMaterialTypeMapProductGroupCommand, MaterialTypeMapProductGroup>();
            CreateMap<UpdateMaterialTypeMapProductGroupCommand, MaterialTypeMapProductGroup>();
            CreateMap<GetMaterialTypeMapProductGroupsQuery, MaterialTypeMapProductGroupParameter>();
        }
    }
}
