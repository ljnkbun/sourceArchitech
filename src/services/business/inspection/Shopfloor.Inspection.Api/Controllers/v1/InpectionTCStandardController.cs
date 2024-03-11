using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.InpectionTCStandards;
using Shopfloor.Inspection.Application.Parameters.InpectionTCStandards;
using Shopfloor.Inspection.Application.Query.InpectionTCStandards;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class InpectionTCStandardController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InpectionTCStandardParameter filter)
        {
            return Ok(await Mediator.Send(new GetInpectionTCStandardsQuery()
            {
                QCRequestArticleId = filter.QCRequestArticleId,
				StockMovementNo = filter.StockMovementNo,
				Grade = filter.Grade,
				Result = filter.Result,
				PersonInChargeId = filter.PersonInChargeId,
				Remark = filter.Remark,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetInpectionTCStandardQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateInpectionTCStandardCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateInpectionTCStandardCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteInpectionTCStandardCommand { Id = id }));
        }
    }
}
