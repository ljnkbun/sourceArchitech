using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingTBRTasks;
using Shopfloor.IED.Application.Parameters.DyeingTBRTasks;
using Shopfloor.IED.Application.Query.DyeingTBRTasks;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingTBRTaskController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingTBRTaskParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingTBRTasksQuery()
            {
                LineNumber = filter.LineNumber,
                MachineCode = filter.MachineCode,
                MachineName = filter.MachineName,
                Temperature = filter.Temperature,
                Minute = filter.Minute,
                DyeingTBRecipeId = filter.DyeingTBRecipeId,
                DyeingOperationId = filter.DyeingOperationId,
                DyeingOperationName = filter.DyeingOperationName,
                DyeingProcessId = filter.DyeingProcessId,
                DyeingProcessName = filter.DyeingProcessName,
                Ratio = filter.Ratio,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDyeingTBRTaskQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingTBRTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDyeingTBRTaskCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingTBRTaskCommand { Id = id }));
        }
    }
}