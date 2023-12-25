using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.ArticleBaseColors
{
    public class ArticleBaseColorModel : BaseModel
    {
        public int ArticleId { get; set; }
        public int WFXColorId { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
    }
}
