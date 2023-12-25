using AutoMapper;

using Shopfloor.Material.Application.Command.DynamicColumns;
using Shopfloor.Material.Application.Models.DynamicColumnContents;
using Shopfloor.Material.Application.Models.DynamicColumns;
using Shopfloor.Material.Application.Parameters.DynamicColumns;
using Shopfloor.Material.Application.Query.DynamicColumns;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Application.Mappings
{
    public class DynamicColumnProfile : Profile
    {
        public DynamicColumnProfile()
        {
            CreateMap<DynamicColumn, DynamicColumnModel>().ReverseMap();
            CreateMap<DynamicColumnContent, DynamicColumnContentModel>().ReverseMap();
            CreateMap<GetDynamicColumnsQuery, DynamicColumnParameter>().ReverseMap();
            CreateMap<CreateDynamicColumnCommand, DynamicColumn>().ReverseMap();
            CreateMap<UpdateDynamicColumnCommand, DynamicColumn>().ReverseMap();
        }
    }
}