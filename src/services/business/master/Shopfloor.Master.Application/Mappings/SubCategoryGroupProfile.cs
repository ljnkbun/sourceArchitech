using AutoMapper;
using Shopfloor.Master.Application.Command.SubCategoryGroups;
using Shopfloor.Master.Application.Models.SubCategoryGroups;
using Shopfloor.Master.Application.Parameters.SubCategoryGroups;
using Shopfloor.Master.Application.Query.SubCategoryGroups;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class SubCategoryGroupProfile : Profile
    {
        public SubCategoryGroupProfile()
        {
            CreateMap<SubCategoryGroup, SubCategoryGroupModel>().ReverseMap();
            CreateMap<CreateSubCategoryGroupCommand, SubCategoryGroup>();
            CreateMap<GetSubCategoryGroupsQuery, SubCategoryGroupParameter>();
        }
    }
}
