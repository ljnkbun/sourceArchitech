using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Query.Articles;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ArticleController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet("history")]
        public async Task<IActionResult> Get(string articleCode)
        {
            return Ok(await Mediator.Send(new GetArticleHistoryQuery() { ArticleCode = articleCode }));
        }
    }
}
