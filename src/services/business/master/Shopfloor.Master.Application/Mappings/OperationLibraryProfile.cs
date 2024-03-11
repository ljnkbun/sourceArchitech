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
                .ForMember(dest => dest.ProcessName, opts => opts.MapFrom(src => src.Process.Name))
                .ForMember(dest => dest.ProcessCode, opts => opts.MapFrom(src => src.Process.Code))
                .ReverseMap();
            CreateMap<CreateOperationLibraryCommand, OperationLibrary>();
            CreateMap<GetOperationLibrariesQuery, OperationLibraryParameter>();
        }
    }
}
