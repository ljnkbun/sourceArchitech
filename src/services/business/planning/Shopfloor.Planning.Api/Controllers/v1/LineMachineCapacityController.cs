using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.LineMachineCapacities;
using Shopfloor.Planning.Application.Parameters.LineMachineCapacities;
using Shopfloor.Planning.Application.Query.LineMachineCapacities;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LineMachineCapacityController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] LineMachineCapacityParameter filter)
        {
            return Ok(await Mediator.Send(new GetLineMachineCapacitiesQuery()
            {
                FromDate = filter.FromDate,
                ToDate = filter.ToDate,
                PlanningGroupId = filter.PlanningGroupId,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                IsActive = filter.IsActive,
            }));
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> CalculateLineMachineCapacity(CalculateLineMachineCapacitiesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
