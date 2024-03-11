using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Processes
{
    public class ProcessParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DefaultArticleOutput { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductGroupId { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryGroupCode { get; set; }
        public int? SubCategoryGroupId { get; set; }
        public int? DivisionId { get; set; }
    }
}