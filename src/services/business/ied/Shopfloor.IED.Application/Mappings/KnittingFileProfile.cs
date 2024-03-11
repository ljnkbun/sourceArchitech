using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingFiles;
using Shopfloor.IED.Application.Models.KnittingFiles;
using Shopfloor.IED.Application.Parameters.KnittingFiles;
using Shopfloor.IED.Application.Query.KnittingFiles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingFiles
{
    public class KnittingFileProfile : Profile
    {
        public KnittingFileProfile()
        {
            CreateMap<KnittingFile, KnittingFileModel>().ReverseMap();
            CreateMap<CreateKnittingFileCommand, KnittingFile>();
            CreateMap<GetKnittingFilesQuery, KnittingFileParameter>();
        }
    }
}
