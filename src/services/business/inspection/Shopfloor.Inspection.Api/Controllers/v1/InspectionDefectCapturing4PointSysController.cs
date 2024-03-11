using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturing4PointSyss;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturing4PointSyss;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionDefectCapturing4PointSysController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionDefectCapturing4PointSysParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionDefectCapturing4PointSyssQuery()
            {
                Inpection4PointSysId = filter.Inpection4PointSysId,
				QCDefectId = filter.QCDefectId,
				DefectQtyOne = filter.DefectQtyOne,
				DefectQtyTwo = filter.DefectQtyTwo,
				DefectQtyThree = filter.DefectQtyThree,
				DefectQtyFour = filter.DefectQtyFour,
				MinorOne = filter.MinorOne,
				MinorTwo = filter.MinorTwo,
				MinorThree = filter.MinorThree,
				MinorFour = filter.MinorFour,
				MajorOne = filter.MajorOne,
				MajorTwo = filter.MajorTwo,
				MajorThree = filter.MajorThree,
				MajorFour = filter.MajorFour,
				ProblemRootCauseId = filter.ProblemRootCauseId,
				ProblemCorrectiveActionId = filter.ProblemCorrectiveActionId,
				ProblemTimelineId = filter.ProblemTimelineId,
				PersonInChargeId = filter.PersonInChargeId,
				AttachmentId = filter.AttachmentId,
				Remark = filter.Remark,
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
            return Ok(await Mediator.Send(new GetInspectionDefectCapturing4PointSysQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionDefectCapturing4PointSysCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionDefectCapturing4PointSysCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionDefectCapturing4PointSysCommand { Id = id }));
        }
    }
}
