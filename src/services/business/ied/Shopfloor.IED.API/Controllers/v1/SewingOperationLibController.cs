﻿using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingOperationLibs;
using Shopfloor.IED.Application.Parameters.SewingOperationLibs;
using Shopfloor.IED.Application.Query.SewingOperationLibs;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingOperationLibController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingOperationLibParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingOperationLibsQuery()
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
                SubCategoryCode = filter.SubCategoryCode,
                SubCategoryName = filter.SubCategoryName,
                SewingComponentId = filter.SewingComponentId,
                FolderTreeId = filter.FolderTreeId,
                BundleTMU = filter.BundleTMU,
                ManualTMU = filter.ManualTMU,
                MachineTMU = filter.MachineTMU,
                NoneMachineTime = filter.NoneMachineTime,
                LabourCost = filter.LabourCost,
                PersonalAllowance = filter.PersonalAllowance,
                MachineDelay = filter.MachineDelay,
                Contingency = filter.Contingency,
                TotalSMV = filter.TotalSMV,
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
            return Ok(await Mediator.Send(new GetSewingOperationLibQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingOperationLibCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingOperationLibCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingOperationLibCommand { Id = id }));
        }
    }
}
