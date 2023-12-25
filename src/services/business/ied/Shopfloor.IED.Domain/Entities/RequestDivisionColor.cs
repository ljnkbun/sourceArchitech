using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestDivisionColor : BaseEntity
    {
        public int RequestDivisionId { get; set; }
        public string Color { get; set; }
        public RequestDivision RequestDivision { get; set; }
    }
}
