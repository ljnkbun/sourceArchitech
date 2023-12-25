using AutoMapper;
using Shopfloor.Master.Application.Command.Grades;
using Shopfloor.Master.Application.Models.Grades;
using Shopfloor.Master.Application.Parameters.Grades;
using Shopfloor.Master.Application.Query.Grades;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Grades
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, GradeModel>().ReverseMap();
            CreateMap<CreateGradeCommand, Grade>();
            CreateMap<GetGradesQuery, GradeParameter>();
        }
    }
}
