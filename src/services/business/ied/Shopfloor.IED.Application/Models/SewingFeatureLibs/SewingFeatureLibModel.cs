using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingFeatureLibs
{
    public class SewingFeatureLibModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FolderTreeId { get; set; }
        public bool Deleted { get; set; }
    }
}
