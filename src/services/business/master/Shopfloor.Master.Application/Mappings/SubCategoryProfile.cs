using AutoMapper;
using Shopfloor.Master.Application.Command.SubCategories;
using Shopfloor.Master.Application.Models.SubCategories;
using Shopfloor.Master.Application.Parameters.SubCategories;
using Shopfloor.Master.Application.Query.SubCategories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategory, SubCategoryModel>()
                .ForMember(dest => dest.ProductGroupCode, opts => opts.MapFrom(src => src.ProductGroup.Code))
                .ForMember(dest => dest.ProductGroupName, opts => opts.MapFrom(src => src.ProductGroup.Name))
                .ForMember(dest => dest.SubCategoryGroupCode, opts => opts.MapFrom(src => src.SubCategoryGroup.Code))
                .ForMember(dest => dest.SubCategoryGroupName, opts => opts.MapFrom(src => src.SubCategoryGroup.Name))
                .ReverseMap();
            CreateMap<CreateSubCategoryCommand, SubCategory>();
            CreateMap<GetSubCategoriesQuery, SubCategoryParameter>();
        }
    }
}
