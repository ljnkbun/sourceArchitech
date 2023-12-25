using Microsoft.AspNetCore.Mvc;
using Shopfloor.Master.Application.Command.CategoryMapMaterialTypes;
using Shopfloor.Master.Application.Parameters.CategoryMapMaterialTypes;
using Shopfloor.Master.Application.Query.CategoryMapMaterialTypes;

namespace Shopfloor.Master.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryMapMaterialTypeController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CategoryMapMaterialTypeParameter filter)
        {
            return Ok(await Mediator.Send(new GetCategoryMapMaterialTypesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                CategoryId = filter.CategoryId,
                MaterialTypeId = filter.MaterialTypeId,
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
            return Ok(await Mediator.Send(new GetCategoryMapMaterialTypeQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryMapMaterialTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCategoryMapMaterialTypeCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryMapMaterialTypeCommand { Id = id }));
        }
    }
}
