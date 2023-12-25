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
            CreateMap<CreateMaterialTypeMapProductGroupCommand, MaterialTypeMapProductGroup>();
            CreateMap<GetMaterialTypeMapProductGroupsQuery, MaterialTypeMapProductGroupParameter>();
        }
    }
}
