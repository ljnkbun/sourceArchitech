using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.WfxGDIs;
using Shopfloor.Barcode.Application.Parameters.WfxGDIs;
using Shopfloor.Barcode.Application.Query.WfxGDIs;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WfxGDIController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WfxGDIParameter filter)
        {
            return Ok(await Mediator.Send(new GetWfxGDIsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                FromOrderDate = filter.FromOrderDate,
                OrderRefNum = filter.OrderRefNum,
                GDITypes = filter.GDITypes,
                GDIType = filter.GDIType,
                GDINum = filter.GDINum,
                SupplierName = filter.SupplierName,
                ToOrderDate = filter.ToOrderDate,
                WareHouse = filter.WareHouse,
                WFXArticleCode = filter.WFXArticleCode,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWfxGDIQuery { Id = id }));
        }


        // GET api/v1/<controller>/5
        [HttpGet("ByArticleCodeOrderRef")]
        public async Task<IActionResult> GetByArticleCodeOrderRef(string articleCode, string orderRefNum)
        {
            return Ok(await Mediator.Send(new GetWfxGDIByArticleCodeOrderRefQuery { WfxArticleCode = articleCode, OrderRefNum = orderRefNum }));
        }


        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWfxGDICommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWfxGDICommand { Id = id }));
        }
    }
}

