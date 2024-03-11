namespace Shopfloor.Planning.Application.Parameters.PORs
{
    public class SyncPorDataParameter
    {
        public string Category { get; set; }
        public string OcNo { get; set; }
        public string LastDays { get; set; }

        public SyncPorDataParameter()
        {
            LastDays = "1";
        }
        public SyncPorDataParameter(string category, string ocNo, string lastDays)
        {
            Category = category;
            OcNo = ocNo;
            LastDays = lastDays;
        }
    }
}
