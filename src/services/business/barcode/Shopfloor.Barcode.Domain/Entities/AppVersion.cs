using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class AppVersion : BaseEntity
    {
        public int FileId { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
    }
}