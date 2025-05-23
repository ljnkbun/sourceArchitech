﻿using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.FolderTrees;
using Shopfloor.IED.Application.Parameters.FolderTrees;
using Shopfloor.IED.Application.Query.FolderTrees;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FolderTreeController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FolderTreeParameter filter)
        {
            return Ok(await Mediator.Send(new GetFolderTreesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Name = filter.Name,
                Level = filter.Level,
                ParentId = filter.ParentId,
                ItemType = filter.ItemType,
                DivisionType = filter.DivisionType,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }
        
        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFolderTreeQuery { Id = id }));
        }

        // GET api/v1/<controller>/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllFolderTreeQuery()));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFolderTreeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateFolderTreeCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFolderTreeCommand { Id = id }));
        }
    }
}
