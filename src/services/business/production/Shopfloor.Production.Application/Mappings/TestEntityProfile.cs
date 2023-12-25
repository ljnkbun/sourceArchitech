using AutoMapper;
using Shopfloor.Production.Application.Command.TestEntities;
using Shopfloor.Production.Application.Models.TestEntities;
using Shopfloor.Production.Application.Parameters.TestEntities;
using Shopfloor.Production.Application.Query.TestEntities;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
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
