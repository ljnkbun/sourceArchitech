using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Command.Imports;
using Shopfloor.Barcode.Application.Parameters.Imports;
using Shopfloor.Barcode.Application.Query.Imports;
using Shopfloor.Barcode.Domain.Enums;

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
                OrderBy = filter.OrderBy,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                Note = filter.Note,
                ArticleName = filter.ArticleName,
                PONo = filter.PONo,
                ArticleCode = filter.ArticleCode,
                IsActive = filter.IsActive,
                Statuses = filter.Statuses,
                Types = filter.Types,
                WfxStatuses = filter.WfxStatuses,
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

        // PUT api/v1/<controller>/5
        [HttpPut("Status")]
        public async Task<IActionResult> Put(UpdateStatusImportCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("Statuses")]
        public async Task<IActionResult> Put(UpdateStatusImportsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteImportCommand { Id = id }));
        }
    }
}
