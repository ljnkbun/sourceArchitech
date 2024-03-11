using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Parameters.WfxGDNs;
using Shopfloor.Barcode.Application.Query.WfxGDNs;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WfxGDNController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WfxGDNParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxGDNsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                FromOrderDate = filter.FromOrderDate,
                GDNNum = filter.GDNNum,
                GDNType = filter.GDNTypes,
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
            return Ok(await Mediator.Send(new GetWfxGDNQuery { Id = id }));
        }


        // GET api/v1/<controller>/5
        [HttpGet("ByArticleCodeGDNNum")]
        public async Task<IActionResult> GetByArticleCodeGDNNum(string articleCode, string gDNNum)
        {
            return Ok(await Mediator.Send(new GetWfxGDNByArticleCodeGDNNumQuery { WfxArticleCode = articleCode, GDNNum = gDNNum }));
        }

    }
}

