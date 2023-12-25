using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestDivisionProcess : BaseEntity
    {
        public RequestDivisionProcess()
        {
            SewingOperationWFXs = new HashSet<SewingOperationWFX>();
            RequestArticleOutputs = new HashSet<RequestArticleOutput>();
        }
        public int RequestDivisionId { get; set; }
        public int ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int LineNumber { get; set; }
        public Status Status { get; set; }
        public virtual RequestDivision RequestDivision { get; set; }
        public virtual ICollection<SewingOperationWFX> SewingOperationWFXs { get; set; }
        public virtual ICollection<RequestArticleOutput> RequestArticleOutputs { get; set; }

    }
}
