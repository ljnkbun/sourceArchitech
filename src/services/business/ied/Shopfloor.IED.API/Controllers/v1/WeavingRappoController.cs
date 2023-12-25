using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingRappos;
using Shopfloor.IED.Application.Parameters.WeavingRappos;
using Shopfloor.IED.Application.Query.WeavingRappos;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingRappoController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingRappoParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingRapposQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                WeavingArticleId = filter.WeavingArticleId,
                YarnOfBorder = filter.YarnOfBorder,
                YarnOfBackground = filter.YarnOfBackground,
                NumOfRappo = filter.NumOfRappo,
                VerticalRappoComment = filter.VerticalRappoComment,
                HorizontalRappoComment = filter.HorizontalRappoComment,
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
            return Ok(await Mediator.Send(new GetWeavingRappoQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingRappoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingRappoCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingRappoCommand { Id = id }));
        }
    }
}
