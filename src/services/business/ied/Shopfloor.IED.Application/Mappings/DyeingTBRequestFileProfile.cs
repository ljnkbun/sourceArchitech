using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBRequestFiles;
using Shopfloor.IED.Application.Models.DyeingTBRequestFiles;
using Shopfloor.IED.Application.Parameters.DyeingTBRequestFiles;
using Shopfloor.IED.Application.Query.DyeingTBRequestFiles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBRequestFileProfile : Profile
    {
        public DyeingTBRequestFileProfile()
        {
            CreateMap<DyeingTBRequestFile, DyeingTBRequestFileModel>().ReverseMap();
            CreateMap<CreateDyeingTBRequestFileCommand, DyeingTBRequestFile>();
            CreateMap<GetDyeingTBRequestFilesQuery, DyeingTBRequestFileParameter>();
        }
    }
}