using Shopfloor.Barcode.Domain.Enums.LevelLocations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.Locations
{
    public class PrintLocationModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentLocationId { get; set; }
        public string Barcode { get; set; }
        public string Location { get; set; }
        public string Site { get; set; }
        public LevelLocation? LevelLocation { get; set; }
    }
}
