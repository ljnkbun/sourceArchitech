using Microsoft.AspNetCore.Mvc;
using Shopfloor.Master.Application.Command.Machines;
using Shopfloor.Master.Application.Parameters.Machines;
using Shopfloor.Master.Application.Query.Machines;

namespace Shopfloor.Master.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MachineController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MachineParameter filter)
        {
            return Ok(await Mediator.Send(new GetMachinesQuery()
            {
                Code = filter.Code,
                Name = filter.Name,
                SerialNo = filter.SerialNo,
                Remarks = filter.Remarks,
                Capacity = filter.Capacity,
                ProcessId = filter.ProcessId,
                FactoryId = filter.FactoryId,
                Gauge = filter.Gauge,
                MachineDiameter = filter.MachineDiameter,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMachineQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMachineCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateMachineCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMachineCommand { Id = id }));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("updategauge")]
        public async Task<IActionResult> UpdateGauge(UpdateGaugeByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
