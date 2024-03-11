using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities
{
    public class MaterialRequestFile : BaseEntity
    {
        public int MaterialRequestId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }

        public virtual MaterialRequest MaterialRequest { get; set; }
    }
}