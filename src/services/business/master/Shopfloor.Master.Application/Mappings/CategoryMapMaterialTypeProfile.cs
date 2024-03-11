using AutoMapper;
using Shopfloor.Master.Application.Command.CategoryMapMaterialTypes;
using Shopfloor.Master.Application.Models.CategoryMapMaterialTypes;
using Shopfloor.Master.Application.Parameters.CategoryMapMaterialTypes;
using Shopfloor.Master.Application.Query.CategoryMapMaterialTypes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.CategoryMapMaterialTypes
{
    public class CategoryMapMaterialTypeProfile : Profile
    {
        public CategoryMapMaterialTypeProfile()
        {
            CreateMap<CategoryMapMaterialType, CategoryMapMaterialTypeModel>().ReverseMap();
            CreateMap<CreateCategoryMapMaterialTypeCommand, CategoryMapMaterialType>();
            CreateMap<UpdateCategoryMapMaterialTypeCommand, CategoryMapMaterialType>();
            CreateMap<GetCategoryMapMaterialTypesQuery, CategoryMapMaterialTypeParameter>();
        }
    }
}
