using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails;
using Shopfloor.Planning.Application.Parameters.StripSchedulePlanningDetails;
using Shopfloor.Planning.Application.Query.StripSchedulePlanningDetails;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StripSchedulePlanningDetailController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StripSchedulePlanningDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetStripSchedulePlanningDetailsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Date = filter.Date,
                StripScheduleId = filter.StripScheduleId,
                StandardCapacity = filter.StandardCapacity,
                ActualCapacity = filter.ActualCapacity,
                Description = filter.Description,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetStripSchedulePlanningDetailQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateStripSchedulePlanningDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateStripSchedulePlanningDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteStripSchedulePlanningDetailCommand { Id = id }));
        }
    }
}
