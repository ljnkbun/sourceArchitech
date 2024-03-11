using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.ProblemCorrectiveActions;
using Shopfloor.Inspection.Application.Parameters.ProblemCorrectiveActions;
using Shopfloor.Inspection.Application.Query.ProblemCorrectiveActions;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProblemCorrectiveActionController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProblemCorrectiveActionParameter filter)
        {
            return Ok(await Mediator.Send(new GetProblemCorrectiveActionsQuery()
            {
                NameVN = filter.NameVN,
				NameEN = filter.NameEN,
				DivisonId = filter.DivisonId,
				DivisonName = filter.DivisonName,
				ProcessId = filter.ProcessId,
				ProcessName = filter.ProcessName,
				CategoryId = filter.CategoryId,
				CategoryName = filter.CategoryName,
				SubCategoryId = filter.SubCategoryId,
				SubCategoryName = filter.SubCategoryName,
				InspectionType = filter.InspectionType,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProblemCorrectiveActionQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProblemCorrectiveActionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProblemCorrectiveActionCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProblemCorrectiveActionCommand { Id = id }));
        }
    }
}
