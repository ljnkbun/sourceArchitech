using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingSpecifications;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingSpecificationController : BaseApiController
    {
        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingSpecificationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>
        [HttpPost("rappo")]
        public async Task<IActionResult> PostRappo(CreateWeavingRappoSpecificationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
