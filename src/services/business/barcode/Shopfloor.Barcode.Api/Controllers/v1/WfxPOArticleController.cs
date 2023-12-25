using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Parameters.WfxPOArticles;
using Shopfloor.Barcode.Application.Query.WfxPOArticles;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WfxPOArticleController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WfxPOArticleParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxPOArticlesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                ArticleType = filter.ArticleTypes,
                FromOrderDate = filter.FromOrderDate,
                OrderRefNum = filter.OrderRefNum,
                OrderType = filter.OrderTypes,
                SupplierName = filter.SupplierName,
                ToOrderDate = filter.ToOrderDate,
                WFXArticleCode = filter.WFXArticleCode,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWfxPOArticleQuery { Id = id }));
        }

    }
}
