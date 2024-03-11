using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.RecipeTasks;
using Shopfloor.IED.Application.Parameters.RecipeTasks;
using Shopfloor.IED.Application.Query.RecipeTasks;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RecipeTaskController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RecipeTaskParameter filter)
        {
            return Ok(await Mediator.Send(new GetRecipeTasksQuery()
            {
                RecipeId = filter.RecipeId,
                DyeingProcessId = filter.DyeingProcessId,
                DyeingProcessName = filter.DyeingProcessName,
                DyeingOperationName = filter.DyeingOperationName,
                DyeingOperationId = filter.DyeingOperationId,
                DyeingProcessCode = filter.DyeingProcessCode,
                DyeingOperationCode = filter.DyeingOperationCode,
                MachineCode = filter.MachineCode,
                MachineName = filter.MachineName,
                Ratio = filter.Ratio,
                Time = filter.Time,
                Temperature = filter.Temperature,
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
            return Ok(await Mediator.Send(new GetRecipeTaskQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecipeTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRecipeTaskCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRecipeTaskCommand { Id = id }));
        }
    }
}