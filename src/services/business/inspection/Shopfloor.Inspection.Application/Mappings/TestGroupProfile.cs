using AutoMapper;
using Shopfloor.Inspection.Application.Command.TestGroups;
using Shopfloor.Inspection.Application.Models.TestGroups;
using Shopfloor.Inspection.Application.Parameters.TestGroups;
using Shopfloor.Inspection.Application.Query.TestGroups;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.TestGroups
{
    public class TestGroupProfile : Profile
    {
        public TestGroupProfile()
        {
            CreateMap<TestGroup, TestGroupModel>().ReverseMap();
            CreateMap<CreateTestGroupCommand, TestGroup>();
            CreateMap<GetTestGroupsQuery, TestGroupParameter>();
        }
    }
}
