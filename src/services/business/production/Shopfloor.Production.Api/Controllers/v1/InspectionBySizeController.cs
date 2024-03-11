using Microsoft.AspNetCore.Mvc;
using Shopfloor.Production.Application.Command.InspectionBySizes;
using Shopfloor.Production.Application.Parameters.InspectionBySizes;
using Shopfloor.Production.Application.Query.InspectionBySizes;

namespace Shopfloor.Production.Api.Controllers.v1
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
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                ProductionOutputId = filter.ProductionOutputId,
                FPPOOutputDetailId = filter.FPPOOutputDetailId,
                MadeQty = filter.MadeQty,
                Length = filter.Length,
                Weight = filter.Weight,
                ActualWeight = filter.ActualWeight,
                OKQty = filter.OKQty,
                BGroupQty = filter.BGroupQty,
                RejectQty = filter.RejectQty,
                CaptureMeter = filter.CaptureMeter,
                CuttingWidth = filter.CuttingWidth,
                WarpDensity = filter.WarpDensity,
                WeftDensity = filter.WeftDensity,

                IsActive = filter.IsActive
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

        // POST api/v1/<controller>
        [HttpPost("CreateBarcode")]
        public async Task<IActionResult> CreateBarcode(CreateBarcodeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>
        [HttpPost("PrintBarcode")]
        public async Task<IActionResult> PrintBarcode(PrintBarcodeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
