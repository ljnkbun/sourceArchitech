using Shopfloor.EventBus.Definations;

namespace Shopfloor.EventBus.Models.Message
{
    public class UpdateStatusImportDetailsMessage
    {
        public int[] ImportDetailIds { get; set; }
        public ItemStatus? Status { get; set; }

        public UpdateStatusImportDetailsMessage(int[] importDetailIds, ItemStatus? status)
        {
            ImportDetailIds = importDetailIds;
            Status = status;
        }
    }

}
