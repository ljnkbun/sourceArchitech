using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestDivisionProcess : BaseEntity
    {
        public RequestDivisionProcess()
        {
            RequestArticleOutputs = new HashSet<RequestArticleOutput>();
        }
        public int RequestDivisionId { get; set; }
        public int ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int LineNumber { get; set; }
        public string Remark { get; set; }
        public virtual RequestDivision RequestDivision { get; set; }
        public virtual ICollection<RequestArticleOutput> RequestArticleOutputs { get; set; }

    }
}
