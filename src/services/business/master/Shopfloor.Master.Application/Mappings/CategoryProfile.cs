using AutoMapper;
using Shopfloor.Master.Application.Command.Categories;
using Shopfloor.Master.Application.Models.Categories;
using Shopfloor.Master.Application.Parameters.Categories;
using Shopfloor.Master.Application.Query.Categories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<GetCategoriesQuery, CategoryParameter>();
        }
    }
}
