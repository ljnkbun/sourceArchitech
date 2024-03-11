using AutoMapper;
using Shopfloor.Planning.Application.Command.MergeSplitPORs;
using Shopfloor.Planning.Application.Models.MergeSplitPorDetails;
using Shopfloor.Planning.Application.Parameters.MergeSplitPorDetails;
using Shopfloor.Planning.Application.Query.MergeSplitPORs;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Mappings
{
    public class MergeSplitPorDetailProfile : Profile
    {
        public MergeSplitPorDetailProfile()
        {
            CreateMap<MergeSplitPorDetail, MergeSplitPorDetailModel>().ReverseMap();
            CreateMap<CreateMergeSplitPORDetailCommand, MergeSplitPorDetail>();
            CreateMap<GetMergeSplitPorDetailsQuery, MergeSplitPorDetailParameter>();
        }
    }
}
