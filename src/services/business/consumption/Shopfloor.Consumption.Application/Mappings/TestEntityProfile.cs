using AutoMapper;
using Shopfloor.Consumption.Application.Command.TestEntities;
using Shopfloor.Consumption.Application.Models.TestEntities;
using Shopfloor.Consumption.Application.Parameters.TestEntities;
using Shopfloor.Consumption.Application.Query.TestEntities;
using Shopfloor.Consumption.Domain.Entities;

namespace Shopfloor.Consumption.Application.Mappings
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
