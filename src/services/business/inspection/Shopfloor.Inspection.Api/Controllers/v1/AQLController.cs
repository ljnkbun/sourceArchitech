using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.AQLs;
using Shopfloor.Inspection.Application.Parameters.AQLs;
using Shopfloor.Inspection.Application.Query.AQLs;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AQLController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AQLParameter filter)
        {
            return Ok(await Mediator.Send(new GetAQLsQuery()
            {
                AQLVersionId = filter.AQLVersionId,
				LotSizeFrom = filter.LotSizeFrom,
				LotSizeTo = filter.LotSizeTo,
				SampleSize = filter.SampleSize,
				Accept = filter.Accept,
				Reject = filter.Reject,
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
            return Ok(await Mediator.Send(new GetAQLQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateAQLCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateAQLCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteAQLCommand { Id = id }));
        }
    }
}
