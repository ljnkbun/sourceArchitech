using Shopfloor.EventBus.Definations;

namespace Shopfloor.EventBus.Models.Message
{
    public class UpdateStatusExportArticlesMessage
    {
        public int[] ExportArticleIds { get; set; }
        public ItemStatus? Status { get; set; }

        public UpdateStatusExportArticlesMessage(int[] exportArticleIds, ItemStatus? status)
        {
            ExportArticleIds = exportArticleIds;
            Status = status;
        }
    }

}
