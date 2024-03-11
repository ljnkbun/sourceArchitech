using Microsoft.AspNetCore.Mvc;
using Shopfloor.Master.Application.Command.Processes;
using Shopfloor.Master.Application.Parameters.Processes;
using Shopfloor.Master.Application.Query.Processes;

namespace Shopfloor.Master.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProcessController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProcessParameter filter)
        {
            return Ok(await Mediator.Send(new GetProcessesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                DefaultArticleOutput = filter.DefaultArticleOutput,
                Code = filter.Code,
                Name = filter.Name,
                DivisionId = filter.DivisionId,
                SubCategoryGroupCode = filter.SubCategoryGroupCode,
                ProductGroupId = filter.ProductGroupId,
                SubCategoryGroupId = filter.SubCategoryGroupId,
                CategoryId = filter.CategoryId,
                SubCategoryId = filter.SubCategoryId,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET: api/v1/<controller>
        [HttpGet("divisioncode")]
        public async Task<IActionResult> GetByDivisionCode([FromQuery] ProcessByDivisionIdParameter filter)
        {
            return Ok(await Mediator.Send(new GetProcessesByDivisionCodeQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                DivisionId = filter.DivisionId,
                DivisionCode = filter.DivisionCode,
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
            return Ok(await Mediator.Send(new GetProcessQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProcessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProcessCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProcessCommand { Id = id }));
        }
    }
}