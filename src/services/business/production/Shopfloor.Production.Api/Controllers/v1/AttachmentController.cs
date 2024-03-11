using Microsoft.AspNetCore.Mvc;
using Shopfloor.Production.Application.Command.Attachments;
using Shopfloor.Production.Application.Parameters.Attachments;
using Shopfloor.Production.Application.Query.Attachments;

namespace Shopfloor.Production.Api.Controllers.v1
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
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                ProductionOutputId = filter.ProductionOutputId,
                DefectCapturing100PointsId = filter.DefectCapturing100PointsId,
                DefectCapturing4PointsId = filter.DefectCapturing4PointsId,
                DefectCapturingStandardId = filter.DefectCapturingStandardId,
                FileName = filter.FileName,
                Description = filter.Description,
                FileId = filter.FileId,
                FileType = filter.FileType,

                IsActive = filter.IsActive
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
