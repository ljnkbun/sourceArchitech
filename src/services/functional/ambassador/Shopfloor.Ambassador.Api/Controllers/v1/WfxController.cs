using Microsoft.AspNetCore.Mvc;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;

namespace Shopfloor.Ambassador.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WfxController : BaseApiController
    {
        // POST: api/v1/<controller>/masterdata
        [HttpPost("masterdata")]
        public async Task<IActionResult> Get([FromBody] WfxMasterDataParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxMasterDataQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                MetaDataFor = filter.MetaDataFor,
            }));
        }

        // GET: api/v1/<controller>/articles
        [HttpPost("article")]
        public async Task<IActionResult> Get([FromBody] WfxArticleParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxArticleQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                SearchDics = filter.SearchDics,
            }));
        }

        // GET: api/v1/<controller>/importPOArticle
        [HttpPost("POArticle")]
        public async Task<IActionResult> Get([FromBody] WfxPOArticleParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxPOArticleQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                SearchDics = filter.SearchDics,
            }));
        }
    }
}
