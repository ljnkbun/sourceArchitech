using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.Exports;
using Shopfloor.Barcode.Application.Parameters.Exports;
using Shopfloor.Barcode.Application.Query.Exports;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ExportController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ExportParameter filter)
        {
            return Ok(await Mediator.Send(new GetExportsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                Types = filter.Types,
                Statuses = filter.Statuses,
                WfxStatuses = filter.WfxStatuses,
                IsActive = filter.IsActive,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetExportQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateExportCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateExportCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("Status")]
        public async Task<IActionResult> Put(UpdateStatusExportCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("Statuses")]
        public async Task<IActionResult> Put(UpdateStatusExportsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteExportCommand { Id = id }));
        }
    }
}
