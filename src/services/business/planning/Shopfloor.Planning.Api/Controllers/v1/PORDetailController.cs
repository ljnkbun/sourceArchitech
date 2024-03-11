using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.PORDetails;
using Shopfloor.Planning.Application.Parameters.PORDetails;
using Shopfloor.Planning.Application.Query.PORDetails;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PORDetailController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PORDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetPORDetailsQuery()
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                Color = filter.Color,
                Type = filter.Type,
                OrderedQuantity = filter.OrderedQuantity,
                Size = filter.Size,
                PORId = filter.PORId,
                RemainingQuantity = filter.RemainingQuantity,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration,
            }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPORDetailQuery() { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePORDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePORDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePODDetailCommand() { Id = id }));
        }
    }
}
