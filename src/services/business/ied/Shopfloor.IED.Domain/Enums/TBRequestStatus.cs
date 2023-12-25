namespace Shopfloor.IED.Domain.Enums
{
    public enum TBRequestStatus : byte
    {
        Draft = 0,
        Pending = 1,
        Analyzing = 2,
        Analyzed = 3,
        Commited = 4
    }
}