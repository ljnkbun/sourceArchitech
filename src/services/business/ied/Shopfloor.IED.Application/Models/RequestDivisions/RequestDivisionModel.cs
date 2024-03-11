using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.RequestDivisions
{
    public class RequestDivisionModel : BaseModel
    {
        public int RequestId { get; set; }
        public int DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string Remark { get; set; }
        public int LineNumber { get; set; }
        public DateTime ExpectedDate { get; set; }
    }
}
