using AutoMapper;

using Shopfloor.Material.Application.Command.MaterialRequestFiles;
using Shopfloor.Material.Application.Models.MaterialRequestFiles;
using Shopfloor.Material.Application.Parameters.MaterialRequestFiles;
using Shopfloor.Material.Application.Query.MaterialRequestFiles;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Application.Mappings
{
    public class MaterialRequestFileProfile : Profile
    {
        public MaterialRequestFileProfile()
        {
            CreateMap<GetMaterialRequestFilesQuery, MaterialRequestFileParameter>();
            CreateMap<CreateMaterialRequestFileCommand, MaterialRequestFile>();
            CreateMap<UpdateMaterialRequestFileCommand, MaterialRequestFile>();
            CreateMap<MaterialRequestFile, MaterialRequestFileModel>().ReverseMap();
        }
    }
}