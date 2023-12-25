using AutoMapper;
using Shopfloor.Inspection.Application.Command.TestEntities;
using Shopfloor.Inspection.Application.Models.TestEntities;
using Shopfloor.Inspection.Application.Parameters.TestEntities;
using Shopfloor.Inspection.Application.Query.TestEntities;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Mappings
{
    public class TestEntityProfile : Profile
    {
        public TestEntityProfile()
        {
            CreateMap<TestEntity, TestEntityModel>().ReverseMap();
            CreateMap<CreateTestEntityCommand, TestEntity>();
            CreateMap<GetTestEntitiesQuery, TestEntityParameter>();
        }
    }
}
