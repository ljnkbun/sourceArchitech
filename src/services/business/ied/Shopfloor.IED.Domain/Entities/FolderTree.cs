using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class FolderTree : BaseEntity
    {
        public FolderTree()
        {
            SubFolders = new HashSet<FolderTree>();
            SewingMacroLibs = new HashSet<SewingMacroLib>();
            SewingOperationLibs = new HashSet<SewingOperationLib>();
            SewingFeatureLibs = new HashSet<SewingFeatureLib>();
        }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public byte Level { get; set; }
        public ItemType ItemType { get; set; }
        public DivisionType DivisionType { get; set; }
        public virtual FolderTree ParentFolder { get; set; }
        public ICollection<FolderTree> SubFolders { get; set; }
        public ICollection<SewingMacroLib> SewingMacroLibs { get; set; }
        public ICollection<SewingOperationLib> SewingOperationLibs { get; set; }
        public ICollection<SewingFeatureLib> SewingFeatureLibs { get; set; }
    }
}
