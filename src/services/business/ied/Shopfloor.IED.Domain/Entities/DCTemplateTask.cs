using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DCTemplateTask : BaseEntity
    {
        public DCTemplateTask()
        {
            DcTemplateDetails = new HashSet<DCTemplateDetail>();
        }
        public int DCTemplateId { get; set; }
        public string MachineName { get; set; }
        public string Temperature { get; set; }
        public int Minute { get; set; }
        public int DyeingProcessId { get; set; }
        public string DyeingProcessName { get; set; }
        public int DyeingOpreationId { get; set; }
        public string DyeingOpreationName { get; set; }
        public int LineNumber { get; set; }
        public string MachineCode { get; set; }
        public virtual DCTemplate DCTemplate { get; set; }
        public virtual ICollection<DCTemplateDetail> DcTemplateDetails { get; set; }
    }
}