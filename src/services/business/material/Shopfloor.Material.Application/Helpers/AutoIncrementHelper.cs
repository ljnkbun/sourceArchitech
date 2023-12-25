using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Application.Helpers
{
    public static class AutoIncrementHelper
    {
        public static string GetNewRequestNo(string inputValue, AutoIncrement autoIncrement)
        {
            return $"{inputValue}{autoIncrement.Separate}{autoIncrement.Index.ToString(autoIncrement.IndexFormat)}";
        }
    }
}
