using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingComponents
{
    public class SewingComponentParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
