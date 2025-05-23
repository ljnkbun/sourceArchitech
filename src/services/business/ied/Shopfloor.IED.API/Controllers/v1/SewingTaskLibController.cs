﻿using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingTaskLibs;
using Shopfloor.IED.Application.Parameters.SewingTaskLibs;
using Shopfloor.IED.Application.Query.SewingTaskLibs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingTaskLibController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingTaskLibParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingTaskLibsQuery()
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
                MachineId = filter.MachineId,
                MachineName = filter.MachineName,
                ManualTMU = filter.ManualTMU,
                MachineTMU = filter.MachineTMU,
                BundleTMU = filter.BundleTMU,
                TotalTMU = filter.TotalTMU,
                BundleTime = filter.BundleTime,
                TaskType = filter.TaskType,
                SewingMachineEfficiencyProfileId = filter.SewingMachineEfficiencyProfileId,
                SewingBundleId = filter.SewingBundleId,
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
            return Ok(await Mediator.Send(new GetSewingTaskLibQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingTaskLibCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingTaskLibCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingTaskLibCommand { Id = id }));
        }
    }
}
