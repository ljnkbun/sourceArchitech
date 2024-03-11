using Microsoft.AspNetCore.Mvc;
using Shopfloor.FileStorage.Application.Command.Files;
using Shopfloor.FileStorage.Application.Parameters.Files;
using Shopfloor.FileStorage.Application.Query.Files;

namespace Shopfloor.FileStorage.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FileController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FileParameter filter)
        {
            return Ok(await Mediator.Send(new GetFilesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                Name = filter.Name,
                Path = filter.Path,
                Extension = filter.Extension,
                Size = filter.Size,
                Folder = filter.Folder,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFileQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>/upload
        [HttpPost("upload")]
        [RequestSizeLimit(104857600)]
        public async Task<IActionResult> Upload([FromForm] UploadFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // GET api/<controller>/download/5
        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            return await Mediator.Send(new DownloadFileByIdCommand { Id = id });
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateFileCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFileCommand { Id = id }));
        }
    }
}
