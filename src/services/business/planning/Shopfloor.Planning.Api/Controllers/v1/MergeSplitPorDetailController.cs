using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.MergeSplitPORs;
using Shopfloor.Planning.Application.Parameters.MergeSplitPorDetails;
using Shopfloor.Planning.Application.Query.MergeSplitPorDetails;
using Shopfloor.Planning.Application.Query.MergeSplitPORs;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MergeSplitPorDetailController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MergeSplitPorDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetMergeSplitPorDetailsQuery()
            {
                FromPorDetailId = filter.FromPorDetailId,
                ToPorDetailId = filter.ToPorDetailId,
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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMergeSplitPorDetailQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMergeSplitPORDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMergeSplitPORDetailCommand { Id = id }));
        }
    }
}
