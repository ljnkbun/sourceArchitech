using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Domain.Entities
{
    public class AutoIncrement : BaseEntity
    {
        public AutoIncrementType Type { get; set; }
        public string Separate { get; set; }
        public int Index { get; set; }
        public string IndexFormat { get; set; }
        public string InputValue { get; set; }
    }
}