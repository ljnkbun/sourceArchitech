using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingFiles;
using Shopfloor.IED.Application.Models.WeavingFiles;
using Shopfloor.IED.Application.Parameters.WeavingFiles;
using Shopfloor.IED.Application.Query.WeavingFiles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingFiles
{
    public class WeavingFileProfile : Profile
    {
        public WeavingFileProfile()
        {
            CreateMap<WeavingFile, WeavingFileModel>().ReverseMap();
            CreateMap<CreateWeavingFileCommand, WeavingFile>();
            CreateMap<GetWeavingFilesQuery, WeavingFileParameter>();
        }
    }
}
