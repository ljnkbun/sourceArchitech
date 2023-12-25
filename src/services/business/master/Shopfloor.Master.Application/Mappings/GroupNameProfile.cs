using AutoMapper;
using Shopfloor.Master.Application.Command.GroupNames;
using Shopfloor.Master.Application.Models.GroupNames;
using Shopfloor.Master.Application.Parameters.GroupNames;
using Shopfloor.Master.Application.Query.GroupNames;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.GroupNames
{
    public class GroupNameProfile : Profile
    {
        public GroupNameProfile()
        {
            CreateMap<GroupName, GroupNameModel>().ReverseMap();
            CreateMap<CreateGroupNameCommand, GroupName>();
            CreateMap<GetGroupNamesQuery, GroupNameParameter>();
        }
    }
}
