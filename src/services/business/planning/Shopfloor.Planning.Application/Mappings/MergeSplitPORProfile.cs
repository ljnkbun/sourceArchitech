using AutoMapper;
using Shopfloor.Planning.Application.Command.MergeSplitPORs;
using Shopfloor.Planning.Application.Models.MergeSplitPORs;
using Shopfloor.Planning.Application.Parameters.MergeSplitPORs;
using Shopfloor.Planning.Application.Query.MergeSplitPORs;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.MergeSplitPORs
{
    public class MergeSplitPORProfile : Profile
    {
        public MergeSplitPORProfile()
        {
            CreateMap<MergeSplitPOR, MergeSplitPORModel>().ReverseMap();
            CreateMap<CreateMergeSplitPORCommand, MergeSplitPOR>();
            CreateMap<GetMergeSplitPORsQuery, MergeSplitPORParameter>();
        }
    }
}
