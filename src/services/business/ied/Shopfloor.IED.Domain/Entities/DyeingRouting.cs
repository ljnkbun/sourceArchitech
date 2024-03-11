using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DyeingRouting : BaseEntity
    {
        public int DyeingIEDId { get; set; }

        public int LineNumber { get; set; }

        public string DyeingProcess { get; set; }

        public string DyeingOperation { get; set; }

        public string DyeingProcessCode { get; set; }

        public string DyeingOperationCode { get; set; }

        public string MachineCode { get; set; }

        public string MachineName { get; set; }

        public decimal Efficiency { get; set; }

        public decimal MachineTime { get; set; }

        public decimal Temperature { get; set; }

        public decimal OperationTime { get; set; }

        public virtual DyeingIED DyeingIED { get; set; }
    }
}