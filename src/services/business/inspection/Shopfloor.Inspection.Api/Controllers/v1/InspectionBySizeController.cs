using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InspectionBySizes;
using Shopfloor.Inspection.Application.Parameters.InspectionBySizes;
using Shopfloor.Inspection.Application.Query.InspectionBySizes;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InspectionBySizeController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InspectionBySizeParameter filter)
        {
            return Ok(await Mediator.Send(new GetInspectionBySizesQuery()
            {
                InspectionId = filter.InspectionId,
                QCRequestDetailId = filter.QCRequestDetailId,
                ColorCode = filter.ColorCode,
				ColorName = filter.ColorName,
				SizeCode = filter.SizeCode,
				SizeName = filter.SizeName,
				Shade = filter.Shade,
				Lot = filter.Lot,
				GRNQty = filter.GRNQty,
				PreInspectedQty = filter.PreInspectedQty,
				LotQty = filter.LotQty,
				InspectionQty = filter.InspectionQty,
				ActualQty = filter.ActualQty,
				NoOfDefect = filter.NoOfDefect,
				OKQty = filter.OKQty,
				BGroupQty = filter.BGroupQty,
				BGroupUsable = filter.BGroupUsable,
				RejectedQty = filter.RejectedQty,
				ExcessShortageQty = filter.ExcessShortageQty,
				ReasonforBGroup = filter.ReasonforBGroup,
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
            return Ok(await Mediator.Send(new GetInspectionBySizeQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInspectionBySizeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInspectionBySizeCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInspectionBySizeCommand { Id = id }));
        }
    }
}
