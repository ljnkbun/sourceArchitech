﻿using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingMacroLibs;
using Shopfloor.IED.Application.Parameters.SewingMacroLibs;
using Shopfloor.IED.Application.Query.SewingMacroLibs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingMacroLibController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingMacroLibParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingMacroLibsQuery()
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
                FolderTreeId = filter.FolderTreeId,
                BundleTMU = filter.BundleTMU,
                MachineTMU = filter.MachineTMU,
                ManualTMU = filter.ManualTMU,
                NoneMachineTime = filter.NoneMachineTime,
                TotalBasicMinutes = filter.TotalBasicMinutes,
                SewingComponentGroupId = filter.SewingComponentGroupId,
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
            return Ok(await Mediator.Send(new GetSewingMacroLibQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingMacroLibCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingMacroLibCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingMacroLibCommand { Id = id }));
        }
    }
}
