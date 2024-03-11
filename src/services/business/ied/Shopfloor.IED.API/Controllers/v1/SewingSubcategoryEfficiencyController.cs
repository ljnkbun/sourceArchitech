using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Application.Models.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Application.Query.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Application.Query.SewingSubcategoryEfficiencys;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingSubcategoryEfficiencyController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingSubcategoryEfficiencyParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingSubcategoryEfficienciesQuery()
            {
                SewingEfficiencyProfileId = filter.SewingEfficiencyProfileId,
                SubCategory = filter.SubCategory,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
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
            return Ok(await Mediator.Send(new GetSewingSubcategoryEfficiencyQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingSubcategoryEfficiencyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateSewingSubcategoryEfficiencyCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingSubcategoryEfficiencyCommand { Id = id }));
        }
    }
}