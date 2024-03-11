using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.StripSchedules;
using Shopfloor.Planning.Application.Parameters.StripSchedules;
using Shopfloor.Planning.Application.Query.StripSchedules;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StripScheduleController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StripScheduleParameter filter)
        {
            return Ok(await Mediator.Send(new GetStripSchedulesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                FromDate = filter.FromDate,
                ToDate = filter.ToDate,
                ProfileEfficiencyValue = filter.ProfileEfficiencyValue,
                OrderEfficiencyValue = filter.OrderEfficiencyValue,
                StripEfficiencyValue = filter.StripEfficiencyValue,
                LearningCurveEfficiencyId = filter.LearningCurveEfficiencyId,
                Description = filter.Description,
                Gauge = filter.Gauge,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetStripScheduleQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateStripScheduleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateStripScheduleCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPost("save")]
        public async Task<IActionResult> SaveStripSchedule(SaveStripSchedulesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate(CalculateStripScheduleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        // PUT api/v1/<controller>/5
        [HttpPost("pull")]
        public async Task<IActionResult> PullCalculate(PullStripScheduleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteStripScheduleCommand { Id = id }));
        }

        // PUT api/v1/<controller>/5
        [HttpPost("capture")]
        public async Task<IActionResult> CaptureStripSchedule(CaptureStripScheduleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
