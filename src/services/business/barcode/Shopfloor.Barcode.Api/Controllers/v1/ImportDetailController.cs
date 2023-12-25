using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Application.Parameters.ImportDetails;
using Shopfloor.Barcode.Application.Query.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    public class ImportDetailController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ImportDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetImportDetailsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                ArticleName = filter.ArticleName,
                ArticleCode = filter.ArticleCode,
                Quantity = filter.Quantity,
                UOM = filter.UOM,
                Unit = filter.Unit,
                Status = filter.Status,
                Shade = filter.Shade,
                OC = filter.OC,
                Color = filter.Color,
                Size = filter.Size,
                NumberOfCone = filter.NumberOfCone,
                WeightPerCone = filter.WeightPerCone,
                Location = filter.Location,
                Note = filter.Note,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
            })); ; ;
        }
        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile file, ImportType importType)
        {
            return Ok(await Mediator.Send(new UploadExcelImportDetailCommand { File = file, ImportType = importType }));
        }

        [HttpGet("Export")]
        public async Task<IActionResult> ExportExcel()
        {
            return await Mediator.Send(new ExportExcelImportDetailsQuery());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetImportDetailQuery { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateImportDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateImportDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("DeleteMulti")]
        public async Task<IActionResult> DeleteMulti(DeleteImportDetailsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("UpdateMulti")]
        public async Task<IActionResult> UpdateMulti(UpdateImportDetailsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteImportDetailCommand { Id = id }));
        }
        [HttpPost("Print")]
        public async Task<IActionResult> Print(PrintImportDetailsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
