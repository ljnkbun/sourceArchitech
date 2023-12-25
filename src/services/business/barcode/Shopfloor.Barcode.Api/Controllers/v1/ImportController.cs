using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.Imports;
using Shopfloor.Barcode.Application.Parameters.Imports;
using Shopfloor.Barcode.Application.Query.Imports;
using Shopfloor.Barcode.Application.Validations.Imports;

namespace Shopfloor.Barcode.Api.Controllers.v1
{
    public class ImportController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ImportParameter filter)
        {
            return Ok(await Mediator.Send(new GetImportsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                Note=filter.Note,
                IsActive = filter.IsActive,
                Status = filter.Status
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetImportQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateImportCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateImportCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteImportCommand { Id = id }));
        }
        // DELETE api/v1/<controller>/5
        [HttpPost("status")]
        public async Task<IActionResult> UpdateStatus(UpdateImportStatusCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
