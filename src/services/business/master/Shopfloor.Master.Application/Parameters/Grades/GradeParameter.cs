using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Grades
{
    public class GradeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
