using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.ProfileEfficiencyDetails;
using Shopfloor.Planning.Application.Parameters.ProfileEfficiencyDetails;
using Shopfloor.Planning.Application.Query.ProfileEfficiencyDetails;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProfileEfficiencyDetailController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProfileEfficiencyDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetProfileEfficiencyDetailsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SubCategoryId = filter.SubCategoryId,
                ProfileEfficiencyId = filter.ProfileEfficiencyId,
                EfficiencyValue = filter.EfficiencyValue,
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
            return Ok(await Mediator.Send(new GetProfileEfficiencyDetailQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProfileEfficiencyDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProfileEfficiencyDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProfileEfficiencyDetailCommand { Id = id }));
        }
    }
}
