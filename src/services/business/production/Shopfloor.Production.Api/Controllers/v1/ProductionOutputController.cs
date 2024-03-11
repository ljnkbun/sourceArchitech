using Microsoft.AspNetCore.Mvc;
using Shopfloor.Production.Application.Command.ProductionOutputs;
using Shopfloor.Production.Application.Parameters.ProductionOutputs;
using Shopfloor.Production.Application.Query.ProductionOutputs;

namespace Shopfloor.Production.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductionOutputController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductionOutputParameter filter)
        {
            return Ok(await Mediator.Send(new GetProductionOutputsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                Code = filter.Code,
                QCDefinitionId = filter.QCDefinitionId,
                FPPOOutputId = filter.FPPOOutputId,
                Remarks = filter.Remarks,
                WFXExportDate = filter.WFXExportDate,
                WFXExportStatus = filter.WFXExportStatus,
                InputDate = filter.InputDate,
                Status = filter.Status,
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
                SystemResult = filter.SystemResult,
                UserResult = filter.UserResult,
                WeightGM2 = filter.WeightGM2,

                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductionOutputQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductionOutputCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductionOutputCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("Status")]
        public async Task<IActionResult> ChangeStatus(ChangeStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductionOutputCommand { Id = id }));
        }
    }
}
