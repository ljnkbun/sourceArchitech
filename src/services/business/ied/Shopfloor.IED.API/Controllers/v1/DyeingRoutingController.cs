using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingRoutings;
using Shopfloor.IED.Application.Command.SewingRoutings;
using Shopfloor.IED.Application.Parameters.DyeingRoutings;
using Shopfloor.IED.Application.Query.DyeingRoutings;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingRoutingController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingRoutingParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingRoutingsQuery()
            {
                DyeingIEDId = filter.DyeingIEDId,
                LineNumber = filter.LineNumber,
                DyeingProcess = filter.DyeingProcess,
                DyeingOperation = filter.DyeingOperation,
                DyeingProcessCode = filter.DyeingProcessCode,
                MachineCode = filter.MachineCode,
                MachineName = filter.MachineName,
                Efficiency = filter.Efficiency,
                MachineTime = filter.MachineTime,
                Temperature = filter.Temperature,
                DyeingOperationCode = filter.DyeingOperationCode,
                OperationTime = filter.OperationTime,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDyeingRoutingQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingRoutingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>/1
        [HttpPost("{dyeingIEDId}")]
        public async Task<IActionResult> Post(int dyeingIEDId, CreateDyeingRoutingsCommand command)
        {
            if (dyeingIEDId != command.DyeingIEDId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut()]
        public async Task<IActionResult> Put(UpdateDyeingRoutingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/1
        [HttpPut("{dyeingIEDId}")]
        public async Task<IActionResult> Put(int dyeingIEDId, UpdateDyeingRoutingsCommand command)
        {
            if (dyeingIEDId != command.DyeingIEDId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingRoutingCommand { Id = id }));
        }
    }
}