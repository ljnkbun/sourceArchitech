using AutoMapper;
using Shopfloor.Master.Application.Command.SizeOrWidthRanges;
using Shopfloor.Master.Application.Models.SizeOrWidthRanges;
using Shopfloor.Master.Application.Parameters.SizeOrWidthRanges;
using Shopfloor.Master.Application.Query.SizeOrWidthRanges;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class SizeOrWidthRangeProfile : Profile
    {
        public SizeOrWidthRangeProfile()
        {
            CreateMap<SizeOrWidthRange, SizeOrWidthRangeModel>().ReverseMap();
            CreateMap<CreateSizeOrWidthRangeCommand, SizeOrWidthRange>();
            CreateMap<GetSizeOrWidthRangesQuery, SizeOrWidthRangeParameter>();
        }
    }
}
