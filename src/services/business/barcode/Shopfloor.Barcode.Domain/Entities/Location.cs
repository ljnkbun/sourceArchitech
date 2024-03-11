using Shopfloor.Barcode.Domain.Enums.LevelLocations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class Location : BaseMasterEntity
    {
        public Location()
        {
            BarcodeLocations = new HashSet<BarcodeLocation>();
        }
        public int? ParentLocationId { get; set; }
        public string Barcode { get; set; }
        public LevelLocation? LevelLocation { get; set; }
        public virtual ICollection<BarcodeLocation> BarcodeLocations { get; set; }
    }
}
