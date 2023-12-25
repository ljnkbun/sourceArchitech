using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.ArticleBaseColors
{
    public class ArticleBaseColorParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? WfxColorId { get; set; }
        public int? ArticleId { get; set; }
    }
}
