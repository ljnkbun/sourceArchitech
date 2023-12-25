using Shopfloor.Barcode.Domain.Enums.LevelLocations;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.Locations
{
    public class LocationParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentLocationId { get; set; }
        public string Barcode { get; set; }
        public LevelLocation? LevelLocation { get; set; }
    }
}
