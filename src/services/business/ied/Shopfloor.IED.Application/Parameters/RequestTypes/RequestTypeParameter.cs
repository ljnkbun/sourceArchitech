using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RequestTypes
{
    public class RequestTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
