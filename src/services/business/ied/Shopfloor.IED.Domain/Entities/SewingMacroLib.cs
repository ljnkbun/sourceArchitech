using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingMacroLib : BaseMasterEntity
    {
        public SewingMacroLib()
        {
            SewingMacroLibBOLs = new HashSet<SewingMacroLibBOL>();
        }
        public string Description { get; set; }
        public int FolderTreeId { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalBasicMinutes { get; set; }
        public decimal NoneMachineTime { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingMacroLibBOL> SewingMacroLibBOLs { get; set; }
        public virtual FolderTree FolderTree { get; set; }
    }
}
