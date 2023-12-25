using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.ShipmentTerms
{
    public class ShipmentTermParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
