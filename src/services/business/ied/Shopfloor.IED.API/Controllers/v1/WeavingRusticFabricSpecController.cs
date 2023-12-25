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
                BackgroundType = filter.BackgroundType,
                BackgroundLoomFrame = filter.BackgroundLoomFrame,
                BorderType = filter.BorderType,
                BorderLoomFrame = filter.BorderLoomFrame,
                WeightGM = filter.WeightGM,
                WeightGM2 = filter.WeightGM2,
                VerticalShrinkage = filter.VerticalShrinkage,
                HorizontalShrinkage = filter.HorizontalShrinkage,
                MachineType = filter.MachineType,
                RPM = filter.RPM,
                CombNum = filter.CombNum,
                CombSize = filter.CombSize,
                VerticalDensity = filter.VerticalDensity,
                HorizontalDensity = filter.HorizontalDensity,
                RusticSize = filter.RusticSize,
                HorizontalDensitySetting = filter.HorizontalDensitySetting,
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
