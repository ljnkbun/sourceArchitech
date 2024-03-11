using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.Attachments;
using Shopfloor.Inspection.Application.Parameters.Attachments;
using Shopfloor.Inspection.Application.Query.Attachments;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AttachmentController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AttachmentParameter filter)
        {
            return Ok(await Mediator.Send(new GetAttachmentsQuery()
            {
                InspectionId = filter.InspectionId,
				FileName = filter.FileName,
				Description = filter.Description,
				FileId = filter.FileId,
				FileType = filter.FileType,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetAttachmentQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateAttachmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateAttachmentCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteAttachmentCommand { Id = id }));
        }
    }
}
