using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Countries
{
    public class CountryParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
