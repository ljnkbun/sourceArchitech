using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingOperations;
using Shopfloor.IED.Application.Parameters.SewingOperations;
using Shopfloor.IED.Application.Query.SewingOperations;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingOperationController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingOperationParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingOperationsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                Description = filter.Description,
                LineCode = filter.LineCode,
                LabourCost = filter.LabourCost,
                BundleTMU = filter.BundleTMU,
                MachineTMU = filter.MachineTMU,
                ManualTMU = filter.ManualTMU,
                NoneMachineTime = filter.NoneMachineTime,
                TotalTMU = filter.TotalTMU,
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
            return Ok(await Mediator.Send(new GetSewingOperationQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingOperationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingOperationCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingOperationCommand { Id = id }));
        }
    }
}
