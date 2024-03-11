using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.WeavingRusticFabricSpecs;
using Shopfloor.IED.Application.Parameters.WeavingRusticFabricSpecs;
using Shopfloor.IED.Application.Query.WeavingRusticFabricSpecs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeavingRusticFabricSpecController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeavingRusticFabricSpecParameter filter)
        {
            return Ok(await Mediator.Send(new GetWeavingRusticFabricSpecsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                WeavingIEDId = filter.WeavingIEDId,
                LineNumber = filter.LineNumber,
                ContentWeaveStyle = filter.ContentWeaveStyle,
                HarnessFrameCWS = filter.HarnessFrameCWS,
                MarginWeaveStyle = filter.MarginWeaveStyle,
                HarnessFrameMWS = filter.HarnessFrameMWS,
                WeightGM = filter.WeightGM,
                WeightGM2 = filter.WeightGM2,
                WarpShrinkage = filter.WarpShrinkage,
                WeftShrinkage = filter.WeftShrinkage,
                MachineType = filter.MachineType,
                RPM = filter.RPM,
                ReedCount = filter.ReedCount,
                ReedWidth = filter.ReedWidth,
                WarpDensity = filter.WarpDensity,
                WeftDensity = filter.WeftDensity,
                GreigeWidth = filter.GreigeWidth,
                SettingWeftDensity = filter.SettingWeftDensity,
                Deleted = filter.Deleted,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetWeavingRusticFabricSpecQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateWeavingRusticFabricSpecCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateWeavingRusticFabricSpecCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteWeavingRusticFabricSpecCommand { Id = id }));
        }
    }
}
