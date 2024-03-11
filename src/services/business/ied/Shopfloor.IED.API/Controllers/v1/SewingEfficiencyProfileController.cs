using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingEfficiencyProfiles;
using Shopfloor.IED.Application.Parameters.SewingEfficiencyProfiles;
using Shopfloor.IED.Application.Query.SewingEfficiencyProfiles;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingEfficiencyProfileController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingEfficiencyProfileParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingEfficiencyProfilesQuery()
            {
                Name = filter.Name,
                PersonalAllowance = filter.PersonalAllowance,
                MachineDelay = filter.MachineDelay,
                Contingency = filter.Contingency,
                IsDefault = filter.IsDefault,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSewingEfficiencyProfileQuery { Id = id }));
        }

        // GET api/v1/<controller>/Default
        [HttpGet("Default")]
        public async Task<IActionResult> GetDefaultAsync()
        {
            return Ok(await Mediator.Send(new GetDefaultSewingEfficiencyProfileQuery()));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingEfficiencyProfileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingEfficiencyProfileCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingEfficiencyProfileCommand { Id = id }));
        }
    }
}