using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingOperationLibResults;
using Shopfloor.IED.Application.Parameters.SewingOperationLibResults;
using Shopfloor.IED.Application.Query.SewingOperationLibResults;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingOperationLibResultController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingOperationLibResultParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingOperationLibResultsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SewingOperationLibId = filter.SewingOperationLibId,
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
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{SewingOperationLibId}")]
        public async Task<IActionResult> Get(int SewingOperationLibId)
        {
            return Ok(await Mediator.Send(new GetSewingOperationLibResultQuery { SewingOperationLibId = SewingOperationLibId }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingOperationLibResultCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateSewingOperationLibResultCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{SewingOperationLibId}")]
        public async Task<IActionResult> Delete(int SewingOperationLibId)
        {
            return Ok(await Mediator.Send(new DeleteSewingOperationLibResultCommand { SewingOperationLibId = SewingOperationLibId }));
        }
    }
}
