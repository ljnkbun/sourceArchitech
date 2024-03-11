using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Helpers
{
    public static class AutoIncrementHelper
    {
        public static string GetNewCode(string inputValue, AutoIncrement autoIncrement)
        {
            return $"{inputValue}{autoIncrement.Separate}{autoIncrement.Index.ToString(autoIncrement.IndexFormat)}";
        }
    }
}