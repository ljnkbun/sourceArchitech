﻿using MassTransit.Futures.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Master.Application.Command.SpinningProcesses;
using Shopfloor.Master.Application.Parameters.SpinningProcesses;
using Shopfloor.Master.Application.Query.SpinningProcesses;

namespace Shopfloor.Master.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SpinningProcessController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SpinningProcessParameter filter)
        {
            return Ok(await Mediator.Send(new GetSpinningProcessesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
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
            return Ok(await Mediator.Send(new GetSpinningProcessQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSpinningProcessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSpinningProcessCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSpinningProcessCommand { Id = id }));
        }
    }
}
