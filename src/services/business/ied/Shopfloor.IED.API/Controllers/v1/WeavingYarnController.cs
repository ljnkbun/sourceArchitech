using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingYarns;
using Shopfloor.IED.Application.Parameters.WeavingYarns;
using Shopfloor.IED.Application.Query.WeavingYarns;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingYarnController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingYarnParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingYarnsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                WeavingArticleId = filter.WeavingArticleId,
                LineNumber = filter.LineNumber,
                YarnType = filter.YarnType,
                YarnCode = filter.YarnCode,
                YarnName = filter.YarnName,
                YarnInRappo = filter.YarnInRappo,
                YarnRatio = filter.YarnRatio,
                SizingRatio = filter.SizingRatio,
                ScaleRatio = filter.ScaleRatio,
                ScrapRatio = filter.ScrapRatio,
                Weight = filter.Weight,
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
            return Ok(await Mediator.Send(new GetWeavingYarnQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingYarnCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingYarnCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingYarnCommand { Id = id }));
        }
    }
}
