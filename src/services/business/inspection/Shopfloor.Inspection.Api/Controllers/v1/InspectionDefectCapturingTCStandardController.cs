using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturingTCStandards;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionDefectCapturingTCStandardController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionDefectCapturingTCStandardParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionDefectCapturingTCStandardsQuery()
            {
                InpectionTCStandardId = filter.InpectionTCStandardId,
				QCDefectId = filter.QCDefectId,
				Defect = filter.Defect,
				AttachmentId = filter.AttachmentId,
				Remark = filter.Remark,
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
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetInspectionDefectCapturingTCStandardQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionDefectCapturingTCStandardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionDefectCapturingTCStandardCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionDefectCapturingTCStandardCommand { Id = id }));
        }
    }
}
