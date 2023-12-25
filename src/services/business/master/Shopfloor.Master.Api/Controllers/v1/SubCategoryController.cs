using Microsoft.AspNetCore.Mvc;
using Shopfloor.Master.Application.Command.SubCategories;
using Shopfloor.Master.Application.Parameters.SubCategories;
using Shopfloor.Master.Application.Query.SubCategories;

namespace Shopfloor.Master.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SubCategoryController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SubCategoryParameter filter)
        {
            return Ok(await Mediator.Send(new GetSubCategoriesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                SubCategoryGroupId = filter.SubCategoryGroupId,
                ExciseTarrifNo = filter.ExciseTarrifNo,
                PackagingUnit = filter.PackagingUnit,
                ByPassPriceList = filter.ByPassPriceList,
                DefaultInactiveIndent = filter.DefaultInactiveIndent,
                ProductGroupId = filter.ProductGroupId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSubCategoryQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSubCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSubCategoryCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSubCategoryCommand { Id = id }));
        }
    }
}
