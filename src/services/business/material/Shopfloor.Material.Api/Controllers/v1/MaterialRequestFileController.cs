using Microsoft.AspNetCore.Mvc;

using Shopfloor.Material.Application.Command.MaterialRequestFiles;
using Shopfloor.Material.Application.Parameters.MaterialRequestFiles;
using Shopfloor.Material.Application.Query.MaterialRequestFiles;

namespace Shopfloor.Material.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MaterialRequestFileController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MaterialRequestFileParameter filter)
        {
            return Ok(await Mediator.Send(new GetMaterialRequestFilesQuery()
            {
                FileId = filter.FileId,
                FileName = filter.FileName,
                Description = filter.Description,
                FileType = filter.FileType,
                MaterialRequestId = filter.MaterialRequestId,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMaterialRequestFileQuery() { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMaterialRequestFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateMaterialRequestFileCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMaterialRequestFileCommand { Id = id }));
        }
    }
}