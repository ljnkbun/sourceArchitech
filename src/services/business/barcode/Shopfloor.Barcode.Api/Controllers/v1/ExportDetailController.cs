using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Application.Parameters.ExportDetails;
using Shopfloor.Barcode.Application.Query.ExportDetails;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ExportDetailController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ExportDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetExportDetailsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                ExportArticleId = filter.ExportArticleId,
                Status = filter.Status,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetExportDetailQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateExportDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>
        [HttpPost("range")]
        public async Task<IActionResult> Post(CreateExportDetailsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateExportDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }


        // PUT api/v1/<controller>/5
        [HttpPut("range")]
        public async Task<IActionResult> Put(UpdateExportDetailsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteExportDetailCommand { Id = id }));
        }

        [HttpDelete("range")]
        public async Task<IActionResult> Deletes(string ids)
        {
            return Ok(await Mediator.Send(new DeleteExportDetailsCommand { Ids = ids }));
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            return Ok(await Mediator.Send(new ImportDataExportDetailCommand { File = file }));
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportExcel([FromQuery] ExportDataExportDetailParameter request)
        {
            return await Mediator.Send(new ExportDataExportDetailsQuery { Ids = request.Ids });
        }

    }
}
