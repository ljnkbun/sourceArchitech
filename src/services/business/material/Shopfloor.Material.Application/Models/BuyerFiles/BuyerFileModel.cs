using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.BuyerFiles
{
    public class BuyerFileModel : BaseModel
    {
        public int BuyerId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }
}