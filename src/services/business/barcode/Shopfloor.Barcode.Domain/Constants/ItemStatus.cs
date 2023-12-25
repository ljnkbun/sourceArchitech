namespace Shopfloor.Barcode.Domain.Constants
{
   
    public enum ItemStatus : byte
    {
        BEFORE_CHECKIN = 0,
        PROCESSING = 2,
        AFTER_CHECKIN = 3,
        CONFIRMED = 1,
    }
    public enum ExportStatus : byte { Processing = 0, Completed = 1, TransfertoWFX = 2 }
    public enum ImportTransferToSiteStatus : byte { Processing = 0, Completed = 1, TransfertoWFX = 2 }
    public enum ImportStatus : byte {  Processing = 0, Completed = 1, TransfertoWFX = 2 }
    public enum ImportType : byte
    {
        ImportPO=0,
        ImportTransferToSite=1
    }
}
