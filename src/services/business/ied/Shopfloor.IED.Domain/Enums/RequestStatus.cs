namespace Shopfloor.IED.Domain.Enums
{
    public enum RequestStatus : byte
    {
        Draft = 0,
        Pending = 1,
        New = 2,
        InProgress = 3,
        Waiting = 4,
        Approved = 5,
        TransferredToWFX = 6,
    }
}