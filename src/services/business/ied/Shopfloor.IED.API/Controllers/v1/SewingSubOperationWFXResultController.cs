using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingSubOperationWFXResults;
using Shopfloor.IED.Application.Parameters.SewingSubOperationWFXResults;
using Shopfloor.IED.Application.Query.SewingSubOperationWFXResults;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingSubOperationWFXResultController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingSubOperationWFXResultParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingSubOperationWFXResultsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SewingSubOperationWFXId = filter.SewingSubOperationWFXId,
                TMU = filter.TMU,
                BasicMunite = filter.BasicMunite,
                PersonalAllowance = filter.PersonalAllowance,
                MachineDelay = filter.MachineDelay,
                Total = filter.Total,
                Contingency = filter.Contingency,
                SMV = filter.SMV,
                Cost = filter.Cost,
                Deleted = filter.Deleted,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{sewingSubOperationWFXId}")]
        public async Task<IActionResult> Get(int sewingSubOperationWFXId)
        {
            return Ok(await Mediator.Send(new GetSewingSubOperationWFXResultQuery { SewingSubOperationWFXId = sewingSubOperationWFXId }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingSubOperationWFXResultCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateSewingSubOperationWFXResultCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{sewingSubOperationWFXId}")]
        public async Task<IActionResult> Delete(int sewingSubOperationWFXId)
        {
            return Ok(await Mediator.Send(new DeleteSewingSubOperationWFXResultCommand { sewingSubOperationWFXId = sewingSubOperationWFXId }));
        }
    }
}
