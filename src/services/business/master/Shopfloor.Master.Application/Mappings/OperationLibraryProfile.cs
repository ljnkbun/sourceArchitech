using AutoMapper;
using Shopfloor.Master.Application.Command.OperationLibraries;
using Shopfloor.Master.Application.Models.OperationLibraries;
using Shopfloor.Master.Application.Parameters.OperationLibraries;
using Shopfloor.Master.Application.Query.OperationLibraries;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class OperationLibraryProfile : Profile
    {
        public OperationLibraryProfile()
        {
            CreateMap<OperationLibrary, OperationLibraryModel>()
                .ForMember(dest => dest.ProcessLibraryName, opts => opts.MapFrom(src => src.ProcessLibrary.Name))
                .ForMember(dest => dest.ProcessLibraryCode, opts => opts.MapFrom(src => src.ProcessLibrary.Code))
                .ReverseMap();
            CreateMap<CreateOperationLibraryCommand, OperationLibrary>();
            CreateMap<GetOperationLibrariesQuery, OperationLibraryParameter>();
        }
    }
}
