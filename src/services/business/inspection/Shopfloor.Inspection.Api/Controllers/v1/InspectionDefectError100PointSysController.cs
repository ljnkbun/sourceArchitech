using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Application.Parameters.InspectionDefectError100PointSyss;
using Shopfloor.Inspection.Application.Query.InspectionDefectError100PointSyss;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionDefectError100PointSysController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionDefectError100PointSysParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionDefectError100PointSyssQuery()
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
            return Ok(await Mediator.Send(new GetInspectionDefectError100PointSysQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionDefectError100PointSysCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionDefectError100PointSysCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionDefectError100PointSysCommand { Id = id }));
        }
    }
}
