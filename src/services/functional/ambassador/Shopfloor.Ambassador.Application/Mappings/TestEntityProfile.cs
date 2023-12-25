using AutoMapper;
using Shopfloor.Ambassador.Application.Command.TestEntities;
using Shopfloor.Ambassador.Application.Models.TestEntities;
using Shopfloor.Ambassador.Application.Parameters.TestEntities;
using Shopfloor.Ambassador.Application.Query.TestEntities;
using Shopfloor.Ambassador.Domain.Entities;

namespace Shopfloor.Ambassador.Application.Mappings
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
