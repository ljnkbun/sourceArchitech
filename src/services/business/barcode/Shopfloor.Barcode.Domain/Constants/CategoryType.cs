using System.ComponentModel.DataAnnotations;

namespace Shopfloor.Barcode.Domain.Constants
{

    public enum CategoryType : byte
    {
        Apparel = 1,
        Fabric = 2,
        [Display(Name = "Textiles/Fabric")]
        TextilesFabric = 3,
        Fiber = 4,
        Yarns = 5,
    }
}
