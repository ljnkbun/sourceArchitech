using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Application.Parameters.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Application.Query.SewingMachineEfficiencyProfiles;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingMachineEfficiencyProfileController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingMachineEfficiencyProfileParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingMachineEfficiencyProfilesQuery()
            {
                SewingEfficiencyProfileId = filter.SewingEfficiencyProfileId,
                MachineId = filter.MachineId,
                MachineName = filter.MachineName,
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
            return Ok(await Mediator.Send(new GetSewingMachineEfficiencyProfileQuery { Id = id }));
        }

        // GET api/v1/<controller>/GetByMachine/5
        [HttpGet("GetByMachine/{machineId}")]
        public async Task<IActionResult> GetByMachine(int machineId)
        {
            return Ok(await Mediator.Send(new GetSewingMachineEfficiencyProfileByMachineQuery { MachineId = machineId }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingMachineEfficiencyProfileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingMachineEfficiencyProfileCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingMachineEfficiencyProfileCommand { Id = id }));
        }
    }
}