using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Material.Application.Parameters.BuyerFiles
{
    public class BuyerFileParameter : RequestParameter
    {
        public int? BuyerId { get; set; }

        public FileType? FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }
}