using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.LearningCurveDetailEfficiencies;
using Shopfloor.Planning.Application.Parameters.LearningCurveDetailEfficiencies;
using Shopfloor.Planning.Application.Query.LearningCurveDetailEfficiencies;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LearningCurveDetailEfficiencyController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] LearningCurveDetailEfficiencyParameter filter)
        {
            return Ok(await Mediator.Send(new GetLearningCurveDetailEfficienciesQuery()
            {
                Code = filter.Code,
                Name = filter.Name,
                LearningCurveEfficiencyId = filter.LearningCurveEfficiencyId,
                EfficiencyValue = filter.EfficiencyValue,
                Days = filter.Days,
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
            return Ok(await Mediator.Send(new GetLearningCurveDetailEfficiencyByIdQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateLearningCurveDetailEfficiencyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateLearningCurveDetailEfficiencyCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteLearningCurveDetailEfficiencyCommand { Id = id }));
        }
    }
}
