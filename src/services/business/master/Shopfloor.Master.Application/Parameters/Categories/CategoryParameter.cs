using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Categories
{
    public class CategoryParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
