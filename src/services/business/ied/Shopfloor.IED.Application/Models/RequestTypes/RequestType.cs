using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.RequestTypes
{
    public class RequestTypeModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
