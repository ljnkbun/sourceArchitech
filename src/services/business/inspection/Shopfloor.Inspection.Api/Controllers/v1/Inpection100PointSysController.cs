using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.Inpection100PointSyss;
using Shopfloor.Inspection.Application.Parameters.Inpection100PointSyss;
using Shopfloor.Inspection.Application.Query.Inpection100PointSyss;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class Inpection100PointSysController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Inpection100PointSysParameter filter)
        {
            return Ok(await Mediator.Send(new GetInpection100PointSyssQuery()
            {
                QCRequestArticleId = filter.QCRequestArticleId,
				StockMovementNo = filter.StockMovementNo,
				CaptureMeter = filter.CaptureMeter,
				ActualWeight = filter.ActualWeight,
				TotalDefect = filter.TotalDefect,
				TotalContDefect = filter.TotalContDefect,
				TotalPoint = filter.TotalPoint,
				PointSquareMeter = filter.PointSquareMeter,
				WarpDensity = filter.WarpDensity,
				WeftDensity = filter.WeftDensity,
				PersonInChargeId = filter.PersonInChargeId,
				Remark = filter.Remark,
				AttachmentId = filter.AttachmentId,
				SystemResult = filter.SystemResult,
				UserResult = filter.UserResult,
				Grade = filter.Grade,
				WeightGM2 = filter.WeightGM2,
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
            return Ok(await Mediator.Send(new GetInpection100PointSysQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInpection100PointSysCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInpection100PointSysCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInpection100PointSysCommand { Id = id }));
        }
    }
}
