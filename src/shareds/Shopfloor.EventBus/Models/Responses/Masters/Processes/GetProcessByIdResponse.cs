using Shopfloor.EventBus.Models.Dtos;

namespace Shopfloor.EventBus.Models.Responses
{
    public class GetProcessByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductGroupId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? SubCategoryGroupId { get; set; }
        public string DefaultArticleOutput { get; set; }
        public int? WFXProcessId { get; set; }
        public List<int> LineIds { get; set; }
        public List<int> MachineIds { get; set; }
    }
}
