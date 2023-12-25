using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities;

public class DynamicColumnContent : BaseEntity
{
    public int DynamicColumnId { get; set; }

    public string Code { get; set; }

    public string Content { get; set; }

    public DynamicColumn DynamicColumn { get; set; }
}