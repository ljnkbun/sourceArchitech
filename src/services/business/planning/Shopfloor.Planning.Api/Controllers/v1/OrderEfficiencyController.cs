﻿using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.OrderEfficiencies;
using Shopfloor.Planning.Application.Parameters.OrderEfficiencies;
using Shopfloor.Planning.Application.Query.OrderEfficiencies;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderEfficiencyController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OrderEfficiencyParameter filter)
        {
            return Ok(await Mediator.Send(new GetOrderEfficienciesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                OCNo = filter.OCNo,
                EfficiencyValue = filter.EfficiencyValue,
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
            return Ok(await Mediator.Send(new GetOrderEfficiencyQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderEfficiencyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateOrderEfficiencyCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteOrderEfficiencyCommand { Id = id }));
        }
    }
}
