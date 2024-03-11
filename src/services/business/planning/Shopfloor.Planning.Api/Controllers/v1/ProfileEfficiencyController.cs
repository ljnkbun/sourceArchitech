using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.ProfileEfficiencies;
using Shopfloor.Planning.Application.Parameters.ProfileEfficiencies;
using Shopfloor.Planning.Application.Query.ProfileEfficiencies;

namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProfileEfficiencyController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProfileEfficiencyParameter filter)
        {
            return Ok(await Mediator.Send(new GetProfileEfficienciesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                CategoryId = filter.CategoryId,
                CategoryCode = filter.CategoryCode,
                CategoryName = filter.CategoryName,
                ProductGroupId = filter.ProductGroupId,
                ProductGroupCode = filter.ProductGroupCode,
                ProductGroupName = filter.ProductGroupName,
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
            return Ok(await Mediator.Send(new GetProfileEfficiencyQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProfileEfficiencyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProfileEfficiencyCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProfileEfficiencyCommand { Id = id }));
        }
    }
}
