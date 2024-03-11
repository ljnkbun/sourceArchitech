using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingRoutingBOLs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingRoutingBOLController : BaseApiController
    {
        // PUT api/v1/<controller>/1
        [HttpPut("{sewingRoutingId}")]
        public async Task<IActionResult> Put(int sewingRoutingId, UpdateSewingRoutingBOLsCommand command)
        {
            if (sewingRoutingId != command.SewingRoutingId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }
    }
}
