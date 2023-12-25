using AutoMapper;
using Shopfloor.Master.Application.Command.SubOperationLibraries;
using Shopfloor.Master.Application.Models.SubOperationLibraries;
using Shopfloor.Master.Application.Parameters.SubOperationLibraries;
using Shopfloor.Master.Application.Query.SubOperationLibraries;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class SubOperationLibraryProfile : Profile
    {
        public SubOperationLibraryProfile()
        {
            CreateMap<SubOperationLibrary, SubOperationLibraryModel>()
                .ForMember(dest => dest.OperationLibraryName, opts => opts.MapFrom(src => src.OperationLibrary.Name))
                .ForMember(dest => dest.OperationLibraryCode, opts => opts.MapFrom(src => src.OperationLibrary.Code))
                .ReverseMap();
            CreateMap<CreateSubOperationLibraryCommand, SubOperationLibrary>();
            CreateMap<GetSubOperationLibrariesQuery, SubOperationLibraryParameter>();
        }
    }
}
