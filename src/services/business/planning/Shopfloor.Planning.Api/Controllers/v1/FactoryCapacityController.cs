using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.FactoryCapacities;
using Shopfloor.Planning.Application.Parameters.FactoryCapacitys;
using Shopfloor.Planning.Application.Query.FactoryCapacitys;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FactoryCapacityController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FactoryCapacityParameter filter)
        {
            return Ok(await Mediator.Send(new GetFactoryCapacitiesQuery()
            {
                FactoryId = filter.FactoryId,
                ProcessId = filter.ProcessId,
                FromDate = filter.FromDate,
                ToDate = filter.ToDate,
                PorNo = filter.PorNo,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                IsActive = filter.IsActive,
            }));
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> CalculateCapacity(CalculateFactoryCapacitiesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
