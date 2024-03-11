using Shopfloor.EventBus.Definations;

namespace Shopfloor.EventBus.Models.Message
{
    public class UpdateStatusImportArticlesMessage
    {
        public int[] ImportArticleIds { get; set; }
        public ItemStatus? Status { get; set; }

        public UpdateStatusImportArticlesMessage(int[] importArticleIds, ItemStatus? status)
        {
            ImportArticleIds = importArticleIds;
            Status = status;
        }
    }

}
