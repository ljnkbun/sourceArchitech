namespace Shopfloor.EventBus.Definations
{
    public enum ItemStatus : byte
    {
        BEFORE_CHECKIN = 0,
        PROCESSING = 2,
        AFTER_CHECKIN = 3,
        CONFIRMED = 1,
    }

    public enum NoteStatus : byte { Processing = 0, Completed = 1, TransfertoWFX = 2 }
}
