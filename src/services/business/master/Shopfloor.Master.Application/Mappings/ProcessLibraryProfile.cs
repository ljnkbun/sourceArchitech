using AutoMapper;
using Shopfloor.Master.Application.Command.ProcessLibraries;
using Shopfloor.Master.Application.Models.ProcessLibraries;
using Shopfloor.Master.Application.Parameters.ProcessLibraries;
using Shopfloor.Master.Application.Query.ProcessLibraries;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ProcessLibraryProfile : Profile
    {
        public ProcessLibraryProfile()
        {
            CreateMap<ProcessLibrary, ProcessLibraryModel>().ReverseMap();
            CreateMap<CreateProcessLibraryCommand, ProcessLibrary>();
            CreateMap<GetProcessLibrariesQuery, ProcessLibraryParameter>();
        }
    }
}
