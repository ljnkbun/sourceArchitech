using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.OneHundredPointSystemDetails;
using Shopfloor.Inspection.Application.Parameters.OneHundredPointSystemDetails;
using Shopfloor.Inspection.Application.Query.OneHundredPointSystemDetails;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OneHundredPointSystemDetailController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OneHundredPointSystemDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetOneHundredPointSystemDetailsQuery()
            {
                FromKg = filter.FromKg,
				ToKg = filter.ToKg,
				FromDefect = filter.FromDefect,
				ToDefect = filter.ToDefect,
				Point = filter.Point,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOneHundredPointSystemDetailQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateOneHundredPointSystemDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateOneHundredPointSystemDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteOneHundredPointSystemDetailCommand { Id = id }));
        }
    }
}
