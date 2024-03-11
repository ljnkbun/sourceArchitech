using AutoMapper;
using Shopfloor.Inspection.Application.Command.Tests;
using Shopfloor.Inspection.Application.Models.Tests;
using Shopfloor.Inspection.Application.Parameters.Tests;
using Shopfloor.Inspection.Application.Query.Tests;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Tests
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<Test, TestModel>().ReverseMap();
            CreateMap<CreateTestCommand, Test>();
            CreateMap<GetTestsQuery, TestParameter>();
        }
    }
}
