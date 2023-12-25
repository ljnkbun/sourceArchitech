using AutoMapper;
using Shopfloor.Master.Application.Command.Departments;
using Shopfloor.Master.Application.Models.Departments;
using Shopfloor.Master.Application.Parameters.Departments;
using Shopfloor.Master.Application.Query.Departments;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentModel>().ReverseMap();
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<GetDepartmentsQuery, DepartmentParameter>();
        }
    }
}
