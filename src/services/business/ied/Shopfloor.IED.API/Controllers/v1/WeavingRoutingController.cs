using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingRoutings;
using Shopfloor.IED.Application.Parameters.WeavingRoutings;
using Shopfloor.IED.Application.Query.WeavingRoutings;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingRoutingController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingRoutingParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingRoutingsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                WeavingIEDId = filter.WeavingIEDId,
                LineNumber = filter.LineNumber,
                WeavingProcess = filter.WeavingProcess,
                WeavingOperation = filter.WeavingOperation,
                MachineType = filter.MachineType,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWeavingRoutingQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingRoutingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingRoutingCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingRoutingCommand { Id = id }));
        }
    }
}
