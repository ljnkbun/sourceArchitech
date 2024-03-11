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
                WeavingProcessCode = filter.WeavingProcessCode,
                WeavingProcess = filter.WeavingProcess,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
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

        // POST api/v1/<controller>/1
        [HttpPost("{weavingIEDId}")]
        public async Task<IActionResult> Post(int weavingIEDId, CreateWeavingRoutingsCommand command)
        {
            if (weavingIEDId != command.WeavingIEDId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>
        [HttpPut()]
        public async Task<IActionResult> Put(UpdateWeavingRoutingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/1
        [HttpPut("{weavingIEDId}")]
        public async Task<IActionResult> Put(int weavingIEDId, UpdateWeavingRoutingsCommand command)
        {
            if (weavingIEDId != command.WeavingIEDId)
                return BadRequest();
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