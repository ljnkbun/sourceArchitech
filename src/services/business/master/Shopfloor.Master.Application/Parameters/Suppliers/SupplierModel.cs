using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Suppliers
{
    public class SupplierParameter : RequestParameter
    {
        public string WFXSupplierId { get; set; }

        public string Name { get; set; }
    }
}
