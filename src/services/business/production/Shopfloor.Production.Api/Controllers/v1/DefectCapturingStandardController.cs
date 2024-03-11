using Microsoft.AspNetCore.Mvc;
using Shopfloor.Production.Application.Command.DefectCapturingStandards;
using Shopfloor.Production.Application.Parameters.DefectCapturingStandards;
using Shopfloor.Production.Application.Query.DefectCapturingStandards;

namespace Shopfloor.Production.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DefectCapturingStandardController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DefectCapturingStandardParameter filter)
        {
            return Ok(await Mediator.Send(new GetDefectCapturingStandardsQuery()
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
                QCDefectId = filter.QCDefectId,
                Defect = filter.Defect,
                AttachmentId = filter.AttachmentId,
                Remark = filter.Remark,
                RootCauseIds = filter.RootCauseIds,
                CorrectiveActionIds = filter.CorrectiveActionIds,
                TimelineId = filter.TimelineId,
                PersonInChargeIds = filter.PersonInChargeIds,

                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDefectCapturingStandardQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDefectCapturingStandardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDefectCapturingStandardCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDefectCapturingStandardCommand { Id = id }));
        }
    }
}
