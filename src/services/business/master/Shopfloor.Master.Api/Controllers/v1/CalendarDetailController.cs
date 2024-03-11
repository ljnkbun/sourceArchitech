using Microsoft.AspNetCore.Mvc;
using Shopfloor.Master.Application.Command.CalendarDetails;
using Shopfloor.Master.Application.Parameters.CalendarDetails;
using Shopfloor.Master.Application.Query.CalendarDetails;

namespace Shopfloor.Master.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CalendarDetailController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CalendarDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetCalendarDetailsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                DayOfWeek = filter.DayOfWeek,
                StartTime = filter.StartTime,
                EndTime = filter.EndTime,
                Shift = filter.Shift,
                WorkingHours = filter.WorkingHours,
                BreakHours = filter.BreakHours,
                CalendarId = filter.CalendarId,
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
            return Ok(await Mediator.Send(new GetCalendarDetailQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCalendarDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCalendarDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCalendarDetailCommand { Id = id }));
        }
    }
}
