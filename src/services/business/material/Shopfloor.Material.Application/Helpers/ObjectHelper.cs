namespace Shopfloor.Material.Application.Helpers
{
    public static class ObjectHelper
    {
        public static T FindDataCodeName<T>(IEnumerable<T> data, string itemName) where T : class => data?.FirstOrDefault(v =>
            (v.GetType().GetProperty("Name")?.GetValue(v)?.ToString()?.Equals(itemName, StringComparison.OrdinalIgnoreCase) ?? false) || (v.GetType().GetProperty("Code")?.GetValue(v)?.ToString()?.Equals(itemName, StringComparison.OrdinalIgnoreCase) ?? false));

        public static void SetDataProperties<TEntity, TModel>(TEntity x, TModel dataFilter, string codePropertyName, string namePropertyName)
            where TModel : class where TEntity : class
        {
            x.GetType().GetProperty(codePropertyName)?.SetValue(x, dataFilter?.GetType().GetProperty("Code")?.GetValue(dataFilter)?.ToString());
            x.GetType().GetProperty(namePropertyName)?.SetValue(x, dataFilter?.GetType().GetProperty("Name")?.GetValue(dataFilter)?.ToString());
        }
    }
}
