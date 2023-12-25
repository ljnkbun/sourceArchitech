using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingSubOperationWFXs;
using Shopfloor.IED.Application.Parameters.SewingSubOperationWFXs;
using Shopfloor.IED.Application.Query.SewingSubOperationWFXs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingSubOperationWFXController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingSubOperationWFXParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingSubOperationWFXsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                WFXProcessCode = filter.WFXProcessCode,
                WFXProcessName = filter.WFXProcessName,
                LineNumber = filter.LineNumber,
                LineCode = filter.LineCode,
                Description = filter.Description,
                BundleTMU = filter.BundleTMU,
                MachineTMU = filter.MachineTMU,
                ManualTMU = filter.ManualTMU,
                TotalSMV = filter.TotalSMV,
                NonMachineTime = filter.NonMachineTime,
                LabourCost = filter.LabourCost,
                QuatityPoints = filter.QuatityPoints,
                QualityComments = filter.QualityComments,
                Freq = filter.Freq,
                Effort = filter.Effort,
                AllowedTime = filter.AllowedTime,
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
            return Ok(await Mediator.Send(new GetSewingSubOperationWFXQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingSubOperationWFXCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingSubOperationWFXCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingSubOperationWFXCommand { Id = id }));
        }
    }
}
