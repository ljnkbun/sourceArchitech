using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.PORs;
using Shopfloor.Planning.Application.Parameters.PORs;
using Shopfloor.Planning.Application.Query.PORs;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PORController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PORParameter filter)
        {
            return Ok(await Mediator.Send(new GetPORsQuery()
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                FromDate = filter.FromDate,
                ToDate = filter.ToDate,
                IsRemaining = filter.IsRemaining,
                PORNo = filter.PORNo,
                WfxPORId = filter.WfxPORId,
                RemainingQuantity = filter.RemainingQuantity,
                Quantity = filter.Quantity,
                ArticleName = filter.ArticleName,
                ArticleCode = filter.ArticleCode,
                WfxArticleId = filter.WfxArticleId,
                Category = filter.Category,
                SubCategory = filter.SubCategory,
                Buyer = filter.Buyer,
                ProductGroup = filter.ProductGroup,
                OCNo = filter.OCNo,
                WfxOCId = filter.WfxOCId,
                DeliveryDate = filter.DeliveryDate,
                BOMId = filter.BOMId,
                BOMNo = filter.BOMNo,
                TypePOR = filter.TypePOR,
                DivisionId = filter.DivisionId,
                DivisionName = filter.DivisionName,
                ProcessId = filter.ProcessId,
                ProcessName = filter.ProcessName,
                IsActive = filter.IsActive,
                IsAllocated = filter.IsAllocated,
                UOM = filter.UOM,
                OrderId = filter.OrderId,
            }));
        }

        // GET: api/v1/<controller>/5
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPORQuery() { Id = id }));
        }

        // POST:  api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePORCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT:  api/v1/<controller>/5
        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, UpdatePORCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // POST:  api/v1/<controller>/5
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePORCommand() { Id = id }));
        }

        // PUT: api/v1/<controller>/5
        [HttpPost("addJobOrderNo")]
        public async Task<IActionResult> AddJobOrderNo(AddJobOrderNoRequestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // GET: api/v1/<controller>/syncpor
        [HttpGet("syncpor")]
        public async Task<IActionResult> SyncPorData([FromQuery] SyncPorDataParameter filter)
        {
            return Ok(await Mediator.Send(new SyncPorDataJobCommand()
            {
                category = filter.Category,
                ocNo = filter.OcNo,
                lastDays = filter.LastDays,
            }));
        }
    }
}
