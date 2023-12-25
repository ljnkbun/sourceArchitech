using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.SupplierTypes
{
    public class SupplierTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
