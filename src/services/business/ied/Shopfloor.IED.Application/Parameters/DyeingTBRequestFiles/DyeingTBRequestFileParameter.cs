using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.DyeingTBRequestFiles
{
    public class DyeingTBRequestFileParameter : RequestParameter
    {
        public int? DyeingTBRequestId { get; set; }

        public FileType? FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }
}