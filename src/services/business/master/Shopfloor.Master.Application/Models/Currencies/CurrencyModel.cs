using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.Currencies
{
    public class CurrencyModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
