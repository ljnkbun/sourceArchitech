using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingRoutings
{
    public class SewingRoutingModel : BaseModel
    {
        public int SewingIEDId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string WFXOperationCode { get; set; }
        public string WFXOperationName { get; set; }
        public int LineNumber { get; set; }
        public decimal SMV { get; set; }
        public bool Deleted { get; set; }
    }
}
