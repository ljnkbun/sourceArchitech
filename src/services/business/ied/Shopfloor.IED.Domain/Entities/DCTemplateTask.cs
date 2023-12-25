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

        public int TaskId { get; set; }

        public string TaskCode { get; set; }

        public string TaskName { get; set; }

        public string Temperature { get; set; }

        public int Minute { get; set; }

        public virtual DCTemplate DCTemplate { get; set; }

        public virtual ICollection<DCTemplateDetail> DcTemplateDetails { get; set; }
    }
}