using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.AppVersions
{
    public class AppVersionModel : BaseModel
    {
        public int FileId { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
    }
}