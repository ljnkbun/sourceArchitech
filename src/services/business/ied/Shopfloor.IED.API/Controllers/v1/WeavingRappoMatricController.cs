using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingRappoMatrics;
using Shopfloor.IED.Application.Parameters.WeavingRappoMatrics;
using Shopfloor.IED.Application.Query.WeavingRappoMatrics;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingRappoMatricController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingRappoMatricParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingRappoMatricsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                WeavingRappoId = filter.WeavingRappoId,
                RowIndex = filter.RowIndex,
                ColumnIndex = filter.ColumnIndex,
                LoopIndex = filter.LoopIndex,
                HorizontalYarnId = filter.HorizontalYarnId,
                VerticleYarnId = filter.VerticleYarnId,
                BackgroundType = filter.BackgroundType,
                Deleted = filter.Deleted,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWeavingRappoMatricQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingRappoMatricCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingRappoMatricCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingRappoMatricCommand { Id = id }));
        }
    }
}
