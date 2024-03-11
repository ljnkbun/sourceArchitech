using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.CriticalParts;
using Shopfloor.Planning.Application.Parameters.CriticalParts;
using Shopfloor.Planning.Application.Query.CriticalParts;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CriticalPartController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CriticalPartParameter filter)
        {
            return Ok(await Mediator.Send(new GetCriticalPartsQuery()
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                IsActive = filter.IsActive,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                PlanningGroupId = filter.PlanningGroupId,
                Name = filter.Name,
                Color = filter.Color,
                Priority = filter.Priority
            }));
        }

        // GET: api/v1/<controller>/5
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCriticalPartQuery() { Id = id }));
        }

        // POST:  api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCriticalPartCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT:  api/v1/<controller>/5
        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, UpdateCriticalPartCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // POST:  api/v1/<controller>/5
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCriticalPartCommand() { Id = id }));
        }
    }
}
