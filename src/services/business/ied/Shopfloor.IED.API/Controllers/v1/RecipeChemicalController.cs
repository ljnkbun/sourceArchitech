using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.RecipeChemicals;
using Shopfloor.IED.Application.Parameters.RecipeChemicals;
using Shopfloor.IED.Application.Query.RecipeChemicals;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RecipeChemicalController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RecipeChemicalParameter filter)
        {
            return Ok(await Mediator.Send(new GetRecipeChemicalsQuery()
            {
                RecipeTaskId = filter.RecipeTaskId,
                ChemicalCode = filter.ChemicalCode,
                ChemicalName = filter.ChemicalName,
                Unit = filter.Unit,
                Value = filter.Value,
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
            return Ok(await Mediator.Send(new GetRecipeChemicalQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecipeChemicalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRecipeChemicalCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRecipeChemicalCommand { Id = id }));
        }
    }
}