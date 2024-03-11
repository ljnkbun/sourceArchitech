namespace Shopfloor.Barcode.Domain.Constants
{

    public enum ItemStatus : byte
    {
        BEFORE_CHECKIN = 0,
        PROCESSING = 2,
        AFTER_CHECKIN = 3,
        CONFIRMED = 1,
    }
}
