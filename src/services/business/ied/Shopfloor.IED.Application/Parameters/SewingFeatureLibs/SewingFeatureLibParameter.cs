using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingFeatureLibs
{
    public class SewingFeatureLibParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? FolderTreeId { get; set; }
        public bool? Deleted { get; set; }
    }
}
