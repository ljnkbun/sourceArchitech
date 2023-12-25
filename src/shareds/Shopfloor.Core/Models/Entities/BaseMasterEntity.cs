namespace Shopfloor.Core.Models.Entities
{
    public abstract class BaseMasterEntity : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
