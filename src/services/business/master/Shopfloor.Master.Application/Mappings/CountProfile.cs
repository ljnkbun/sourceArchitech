using AutoMapper;
using Shopfloor.Master.Application.Command.Counts;
using Shopfloor.Master.Application.Models.Counts;
using Shopfloor.Master.Application.Parameters.Counts;
using Shopfloor.Master.Application.Query.Counts;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Counts
{
    public class CountProfile : Profile
    {
        public CountProfile()
        {
            CreateMap<Count, CountModel>().ReverseMap();
            CreateMap<CreateCountCommand, Count>();
            CreateMap<GetCountsQuery, CountParameter>();
        }
    }
}
