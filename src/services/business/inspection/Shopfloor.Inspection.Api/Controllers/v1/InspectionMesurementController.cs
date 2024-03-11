using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InspectionMesurements;
using Shopfloor.Inspection.Application.Parameters.InspectionMesurements;
using Shopfloor.Inspection.Application.Query.InspectionMesurements;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionMesurementController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionMesurementParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionMesurementsQuery()
            {
                InspectionId = filter.InspectionId,
                QCDefectId = filter.QCDefectId,
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
            return Ok(await Mediator.Send(new GetInspectionMesurementQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionMesurementCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionMesurementCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionMesurementCommand { Id = id }));
        }
    }
}
