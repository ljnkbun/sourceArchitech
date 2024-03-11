using Microsoft.AspNetCore.Mvc;
using Shopfloor.Production.Application.Command.DefectCapturings;
using Shopfloor.Production.Application.Parameters.DefectCapturings;
using Shopfloor.Production.Application.Query.DefectCapturings;

namespace Shopfloor.Production.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DefectCapturingController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DefectCapturingParameter filter)
        {
            return Ok(await Mediator.Send(new GetDefectCapturingsQuery()
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
                Minor = filter.Minor,
                Major = filter.Major,
                Critical = filter.Critical,
                ParentId = filter.ParentId,
                RootCauseIds = filter.RootCauseIds,
                PersonInChargeIds = filter.PersonInChargeIds,
                CorrectActionIds = filter.CorrectActionIds,
                IsLongError = filter.IsLongError,
                LongErrorFrom = filter.LongErrorFrom,
                LongErrorTo = filter.LongErrorTo,
                ErrorCode = filter.ErrorCode,
                ErrorName = filter.ErrorName,
                TimelineId = filter.TimelineId,

                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDefectCapturingQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDefectCapturingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDefectCapturingCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDefectCapturingCommand { Id = id }));
        }
    }
}
