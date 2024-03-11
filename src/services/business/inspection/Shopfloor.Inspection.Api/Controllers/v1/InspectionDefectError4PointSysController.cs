using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectError4PointSyss;
using Shopfloor.Inspection.Application.Query.InspectionDefectError4PointSyss;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionDefectError4PointSysController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionDefectError4PointSysParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionDefectError4PointSyssQuery()
            {
                InspectionDefectCapturing4PointSysId = filter.InspectionDefectCapturing4PointSysId,
				ErrorType = filter.ErrorType,
				From = filter.From,
				To = filter.To,
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
            return Ok(await Mediator.Send(new GetInspectionDefectError4PointSysQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionDefectError4PointSysCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionDefectError4PointSysCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionDefectError4PointSysCommand { Id = id }));
        }
    }
}
