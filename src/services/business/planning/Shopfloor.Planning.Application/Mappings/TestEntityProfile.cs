using AutoMapper;
using Shopfloor.Planning.Application.Command.TestEntities;
using Shopfloor.Planning.Application.Models.TestEntities;
using Shopfloor.Planning.Application.Parameters.TestEntities;
using Shopfloor.Planning.Application.Query.TestEntities;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Mappings
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
