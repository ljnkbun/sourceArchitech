using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingTBRChemicals;
using Shopfloor.IED.Application.Parameters.DyeingTBRChemicals;
using Shopfloor.IED.Application.Query.DyeingTBRChemicals;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingTBRChemicalController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingTBRChemicalParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingTBRChemicalsQuery()
            {
                DyeingTBRTaskId = filter.DyeingTBRTaskId,
                ChemicalId = filter.ChemicalId,
                ChemicalCode = filter.ChemicalCode,
                Unit = filter.Unit,
                ChemicalName = filter.ChemicalName,
                ChemicalSubCategory = filter.ChemicalSubCategory,
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
            return Ok(await Mediator.Send(new GetDyeingTBRChemicalQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingTBRChemicalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDyeingTBRChemicalCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingTBRChemicalCommand { Id = id }));
        }
    }
}