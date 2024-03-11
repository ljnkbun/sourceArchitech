using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.SewingOperationLibBOLs
{
    public class SewingOperationLibBOLModel : BaseModel
    {
        public int SewingOperationLibId { get; set; }
        public int? SewingTaskLibId { get; set; }
        public int? SewingMacroLibId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public OperationBOLType Type { get; set; }
        public string Description { get; set; }
        public int LineNumber { get; set; }
        public string Freq { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? BundleTime { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal Allowance { get; set; }
    }
}
