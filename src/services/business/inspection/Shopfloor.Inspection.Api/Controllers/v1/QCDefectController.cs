using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.QCDefects;
using Shopfloor.Inspection.Application.Parameters.QCDefects;
using Shopfloor.Inspection.Application.Query.QCDefects;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class QCDefectController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QCDefectParameter filter)
        {
            return Ok(await Mediator.Send(new GetQCDefectsQuery()
            {
                QCDefecTypeId = filter.QCDefecTypeId,
				ParrentId = filter.ParrentId,
				NameEN = filter.NameEN,
				DivisonId = filter.DivisonId,
				DivisonName = filter.DivisonName,
				ProcessId = filter.ProcessId,
				ProcessName = filter.ProcessName,
				CategoryId = filter.CategoryId,
				CategoryName = filter.CategoryName,
				SubCategoryId = filter.SubCategoryId,
				SubCategoryName = filter.SubCategoryName,
				Level = filter.Level,
				InspectionType = filter.InspectionType,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetQCDefectQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateQCDefectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateQCDefectCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteQCDefectCommand { Id = id }));
        }
    }
}
