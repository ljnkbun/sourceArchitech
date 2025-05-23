﻿using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.Requests;
using Shopfloor.IED.Application.Parameters.Requests;
using Shopfloor.IED.Application.Query.Requests;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RequestController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestIEDParameter filter)
        {
            return Ok(await Mediator.Send(new GetRequestsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                RequestNo = filter.RequestNo,
                Description = filter.Description,
                Status = filter.Status,
                StatusComment = filter.StatusComment,
                ExpectedQty = filter.ExpectedQty,
                RequestTypeId = filter.RequestTypeId,
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
            return Ok(await Mediator.Send(new GetRequestQuery { Id = id }));
        }
        [HttpGet("GetFullRouting/{id}")]
        public async Task<IActionResult> GetFullRouting(int id)
        {
            return Ok(await Mediator.Send(new GetFullRoutingRequestQuery { Id = id }));
        }
        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRequestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>/Submit/1
        [HttpPut("Submit/{id}")]
        public async Task<IActionResult> Submit(int id)
        {
            return Ok(await Mediator.Send(new SubmitRequestCommand { Id = id }));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRequestCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRequestCommand { Id = id }));
        }
    }
}
