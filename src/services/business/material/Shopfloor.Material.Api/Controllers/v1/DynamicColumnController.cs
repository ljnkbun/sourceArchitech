using Microsoft.AspNetCore.Mvc;

using Shopfloor.Material.Application.Command.DynamicColumns;
using Shopfloor.Material.Application.Parameters.DynamicColumns;
using Shopfloor.Material.Application.Query.DynamicColumns;

namespace Shopfloor.Material.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DynamicColumnController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DynamicColumnParameter filter)
        {
            return Ok(await Mediator.Send(new GetDynamicColumnsQuery()
            {
                Name = filter.Name,
                FieldType = filter.FieldType,
                Code = filter.Code,
                IsRequired = filter.IsRequired,
                IsContent = filter.IsContent,
                CategoryCode = filter.CategoryCode,
                DisplayIndex = filter.DisplayIndex,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                CreatedFrom = filter.CreatedFrom,
                CreatedTo = filter.CreatedTo,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDynamicColumnQuery() { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDynamicColumnCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDynamicColumnCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDynamicColumnCommand { Id = id }));
        }
    }
}