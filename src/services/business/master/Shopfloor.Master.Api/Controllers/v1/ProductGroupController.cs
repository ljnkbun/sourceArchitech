using Microsoft.AspNetCore.Mvc;
using Shopfloor.Master.Application.Command.ProductGroups;
using Shopfloor.Master.Application.Parameters.ProductGroups;
using Shopfloor.Master.Application.Query.ProductGroups;

namespace Shopfloor.Master.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductGroupController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductGroupParameter filter)
        {
            return Ok(await Mediator.Send(new GetProductGroupsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                CategoryId = filter.CategoryId,
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
            return Ok(await Mediator.Send(new GetProductGroupQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductGroupCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductGroupCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductGroupCommand { Id = id }));
        }
    }
}
