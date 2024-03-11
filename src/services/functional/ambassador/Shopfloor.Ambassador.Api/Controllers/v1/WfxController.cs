using Microsoft.AspNetCore.Mvc;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.Ambassador.Application.Query.Wfxs;

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

        // GET: api/v1/<controller>/POArticle
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

        // GET: api/v1/<controller>/GDI
        [HttpPost("GDI")]
        public async Task<IActionResult> Get([FromBody] WfxGDIParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxGDIQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                WFXAPIGDIMovementData = filter.WFXAPIGDIMovementData,
            }));
        }


        // GET: api/v1/<controller>/WFXImportSync
        [HttpPost("WFXImportSync")]
        public async Task<IActionResult> Get([FromBody] List<WfxImportSyncParameter> parameters)
        {
            return Ok(await Mediator.Send(new GetWfxImportSyncQuery()
            {
                Parameters = parameters
            }));
        }

        // GET: api/v1/<controller>/WFXExportSync
        [HttpPost("WFXExportSync")]
        public async Task<IActionResult> Get([FromBody] WfxExportSyncParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxExportSyncQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                ColorCode = filter.ColorCode,
                OrderRefNum = filter.OrderRefNum,
                OrderType = filter.OrderType,
                ReceiptType = filter.ReceiptType,
                SizeCode = filter.SizeCode,
                WFXArticleCode = filter.WFXArticleCode,
            }));
        }

        [HttpGet("WFXSyncPor")]
        public async Task<IActionResult> Get([FromQuery] WfxPorParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxPorDataQuery()
            {
                Category = filter.Category,
                OcNo = filter.OCNO,
                GETLastDays = filter.GETLastDays,
            }));
        }
        [HttpPost("WFXCommonDataGetDDL")]
        public async Task<IActionResult> Get([FromBody] WFXGetDDLParameter filter)
        {
            return Ok(await Mediator.Send(new WFXCommonDataGetDDLQuery()
            {
                ObjectType = filter.ObjectType,
                PageParam = filter.PageParam,
            }));
        }
    }
}
