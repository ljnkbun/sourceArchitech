using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.KnittingRoutings;
using Shopfloor.IED.Application.Command.SewingRoutings;
using Shopfloor.IED.Application.Parameters.KnittingRoutings;
using Shopfloor.IED.Application.Query.KnittingRoutings;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class KnittingRoutingController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] KnittingRoutingParameter filter)
        {
            return Ok(await Mediator.Send(new GetKnittingRoutingsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                KnittingIEDId = filter.KnittingIEDId,
                LineNumber = filter.LineNumber,
                KnittingOperationCode = filter.KnittingOperationCode,
                KnittingProcessCode = filter.KnittingProcessCode,
                KnittingProcess = filter.KnittingProcess,
                KnittingOperation = filter.KnittingOperation,
                MachineTypeId =filter.MachineTypeId,
                MachineTypeName = filter.MachineTypeName,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetKnittingRoutingQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateKnittingRoutingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>/1
        [HttpPost("{knittingIEDId}")]
        public async Task<IActionResult> Post(int knittingIEDId, CreateKnittingRoutingsCommand command)
        {
            if (knittingIEDId != command.KnittingIEDId) 
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>
        [HttpPut()]
        public async Task<IActionResult> Put(UpdateKnittingRoutingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/1
        [HttpPut("{knittingIEDId}")]
        public async Task<IActionResult> Put(int knittingIEDId, UpdateKnittingRoutingsCommand command)
        {
            if (knittingIEDId != command.KnittingIEDId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteKnittingRoutingCommand { Id = id }));
        }
    }
}
