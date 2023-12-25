using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.RequestDivisionFiles;
using Shopfloor.IED.Application.Parameters.RequestDivisionFiles;
using Shopfloor.IED.Application.Query.RequestDivisionFiles;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RequestDivisionFileController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestDivisionFileParameter filter)
        {
            return Ok(await Mediator.Send(new GetRequestDivisionFilesQuery()
            {
                RequestDivisionId = filter.RequestDivisionId,
                FileType = filter.FileType,
                FileName = filter.FileName,
                FileId = filter.FileId,
                Description = filter.Description,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRequestDivisionFileQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRequestDivisionFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRequestDivisionFileCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRequestDivisionFileCommand { Id = id }));
        }
    }
}
