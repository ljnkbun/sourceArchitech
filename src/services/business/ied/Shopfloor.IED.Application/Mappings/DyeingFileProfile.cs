using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingFiles;
using Shopfloor.IED.Application.Models.DyeingFiles;
using Shopfloor.IED.Application.Parameters.DyeingFiles;
using Shopfloor.IED.Application.Query.DyeingFiles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.DyeingFiles
{
    public class DyeingFileProfile : Profile
    {
        public DyeingFileProfile()
        {
            CreateMap<DyeingFile, DyeingFileModel>().ReverseMap();
            CreateMap<CreateDyeingFileCommand, DyeingFile>();
            CreateMap<GetDyeingFilesQuery, DyeingFileParameter>();
        }
    }
}
