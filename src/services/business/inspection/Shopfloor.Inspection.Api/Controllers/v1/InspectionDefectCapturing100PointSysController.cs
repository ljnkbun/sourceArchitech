using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturing100PointSyss;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionDefectCapturing100PointSysController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionDefectCapturing100PointSysParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionDefectCapturing100PointSyssQuery()
            {
                Inpection100PointSysId = filter.Inpection100PointSysId,
				QCDefectId = filter.QCDefectId,
				Minor = filter.Minor,
				Major = filter.Major,
				Critial = filter.Critial,
				AttachmentId = filter.AttachmentId,
				ProblemRootCauseId = filter.ProblemRootCauseId,
				ProblemCorrectiveActionId = filter.ProblemCorrectiveActionId,
				ProblemTimelineId = filter.ProblemTimelineId,
				PersonInChargeId = filter.PersonInChargeId,
				Remark = filter.Remark,
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
            return Ok(await Mediator.Send(new GetInspectionDefectCapturing100PointSysQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionDefectCapturing100PointSysCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionDefectCapturing100PointSysCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionDefectCapturing100PointSysCommand { Id = id }));
        }
    }
}
