using AutoMapper;
using Shopfloor.FileStorage.Application.Command.Files;
using Shopfloor.FileStorage.Application.Extensions;
using Shopfloor.FileStorage.Application.Models;
using Shopfloor.FileStorage.Application.Parameters.Files;
using Shopfloor.FileStorage.Application.Query.Files;

namespace Shopfloor.FileStorage.Application.Mappings
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<Domain.Entities.File, FileModel>().ReverseMap();
            CreateMap<CreateFileCommand, Domain.Entities.File>()
                .ForMember(dest => dest.Path, opts => opts.MapFrom(src => $"{src.Folder}/{src.Name}"));
            CreateMap<GetFilesQuery, FileParameter>();

            CreateMap<Domain.Entities.File, UploadFileModel>()
                .ForMember(dest => dest.FileType, opts => opts.MapFrom(src => src.Extension.GetFileType()));
        }
    }
}
