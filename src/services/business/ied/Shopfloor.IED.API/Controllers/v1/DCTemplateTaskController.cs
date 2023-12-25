using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DCTemplateTask;
using Shopfloor.IED.Application.Command.DCTemplateTasks;
using Shopfloor.IED.Application.Parameters.DCTemplateTasks;
using Shopfloor.IED.Application.Query.DCTemplateTasks;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DCTemplateTaskController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DCTemplateTaskParameter filter)
        {
            return Ok(await Mediator.Send(new GetDCTemplateTasksQuery()
            {
                DCTemplateId = filter.DCTemplateId,
                TaskCode = filter.TaskCode,
                TaskName = filter.TaskName,
                Temperature = filter.Temperature,
                Minute = filter.Minute,
                TaskId = filter.TaskId,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDCTemplateTaskQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDCTemplateTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDCTemplateTaskCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDCTemplateTaskCommand { Id = id }));
        }
    }
}