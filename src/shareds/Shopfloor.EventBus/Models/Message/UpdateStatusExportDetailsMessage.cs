using Shopfloor.EventBus.Definations;

namespace Shopfloor.EventBus.Models.Message
{
    public class UpdateStatusExportDetailsMessage
    {
        public int[] ExportDetailIds { get; set; }
        public ItemStatus? Status { get; set; }

        public UpdateStatusExportDetailsMessage(int[] exportDetailIds, ItemStatus? status)
        {
            ExportDetailIds = exportDetailIds;
            Status = status;
        }
    }

}
