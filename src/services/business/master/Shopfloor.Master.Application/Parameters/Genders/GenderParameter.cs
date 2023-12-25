using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Genders
{
    public class GenderParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
