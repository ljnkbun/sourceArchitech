namespace Shopfloor.Barcode.Domain.Constants
{

    public enum ExportStatus : byte { Processing = 0, Completed = 1, TransfertoWFX = 2 }
    public enum ExportTypes : byte
    {
        TransferToSite = 1,
        ReturnToSupplier = 2,
        BuyerOrderDispatch = 3,
        MaterialBatching = 4,
    }
}
