using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturings;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionDefectCapturingController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionDefectCapturingParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionDefectCapturingsQuery()
            {
                InspectionId = filter.InspectionId,
                QCDefectId=filter.QCDefectId,
                Minor = filter.Minor,
				Major = filter.Major,
				Critial = filter.Critial,
				ProblemRootCauseId = filter.ProblemRootCauseId,
				ProblemCorrectiveActionId = filter.ProblemCorrectiveActionId,
				ProblemTimelineId = filter.ProblemTimelineId,
				PersonInChargeId = filter.PersonInChargeId,
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
            return Ok(await Mediator.Send(new GetInspectionDefectCapturingQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionDefectCapturingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionDefectCapturingCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionDefectCapturingCommand { Id = id }));
        }
    }
}
