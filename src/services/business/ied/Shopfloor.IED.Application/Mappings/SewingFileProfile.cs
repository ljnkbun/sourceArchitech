using AutoMapper;
using Shopfloor.IED.Application.Command.SewingFiles;
using Shopfloor.IED.Application.Models.SewingFiles;
using Shopfloor.IED.Application.Parameters.SewingFiles;
using Shopfloor.IED.Application.Query.SewingFiles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingFiles
{
    public class SewingFileProfile : Profile
    {
        public SewingFileProfile()
        {
            CreateMap<SewingFile, SewingFileModel>().ReverseMap();
            CreateMap<CreateSewingFileCommand, SewingFile>();
            CreateMap<GetSewingFilesQuery, SewingFileParameter>();
        }
    }
}
