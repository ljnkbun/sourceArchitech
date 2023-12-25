using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Currencies
{
    public class CurrencyParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
