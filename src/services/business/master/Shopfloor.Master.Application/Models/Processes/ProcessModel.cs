using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.Processes
{
    public class ProcessModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DefaultArticleOutput { get; set; }
        public int? WFXProcessId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int? ProductGroupId { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int? SubCategoryGroupId { get; set; }
        public string SubCategoryGroupCode { get; set; }
        public string SubCategoryGroupName { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
    }
}