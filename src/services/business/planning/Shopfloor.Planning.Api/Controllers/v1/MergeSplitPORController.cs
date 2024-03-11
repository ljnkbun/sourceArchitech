using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.MergeSplitPORs;
using Shopfloor.Planning.Application.Command.PORs;
using Shopfloor.Planning.Application.Parameters.MergeSplitPORs;
using Shopfloor.Planning.Application.Query.MergeSplitPORs;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MergeSplitPORController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MergeSplitPORParameter filter)
        {
            return Ok(await Mediator.Send(new GetMergeSplitPORsQuery()
            {
                FromPORId = filter.FromPORId,
                ToPORId = filter.ToPORId,
                Quantity = filter.Quantity,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMergeSplitPORQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMergeSplitPORCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{porId}")]
        public async Task<IActionResult> Delete(int porId)
        {
            return Ok(await Mediator.Send(new DeleteMergeSplitPORCommand { PorId = porId }));
        }

        [HttpPost("merge")]
        public async Task<IActionResult> Merge(MergePORCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("split")]
        public async Task<IActionResult> Split(SplitPORCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
