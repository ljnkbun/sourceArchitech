using Microsoft.AspNetCore.Mvc;
using Shopfloor.Consumption.Application.Command.TestEntities;
using Shopfloor.Consumption.Application.Parameters.TestEntities;
using Shopfloor.Consumption.Application.Query.TestEntities;

namespace Shopfloor.Consumption.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TestEntityController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TestEntityParameter filter)
        {
            return Ok(await Mediator.Send(new GetTestEntitiesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                Property01 = filter.Property01,
                Property02 = filter.Property02,
                Type = filter.Type,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTestEntityQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateTestEntityCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTestEntityCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTestEntityCommand { Id = id }));
        }
    }
}
