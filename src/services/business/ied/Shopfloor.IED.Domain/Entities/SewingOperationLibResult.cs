using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingOperationLibResult : BaseEntity
    {
        public int SewingOperationLibId { get; set; }
        public ResultType Type { get; set; }
        public decimal TMU { get; set; }
        public decimal BasicMinute { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal? MachineDelay { get; set; }
        public decimal Total { get; set; }
        public decimal Contingency { get; set; }
        public decimal? SMV { get; set; }
        public decimal Cost { get; set; }
        public bool Deleted { get; set; }
        public virtual SewingOperationLib SewingOperationLib { get; set; }
    }
}
