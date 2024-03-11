using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingProcessChemicals;
using Shopfloor.IED.Application.Parameters.DyeingProcessChemicals;
using Shopfloor.IED.Application.Query.DyeingProcessChemicals;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingProcessChemicalController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingProcessChemicalParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingProcessChemicalsQuery()
            {
                DyeingRoutingId = filter.DyeingRoutingId,
                ChemicalCode = filter.ChemicalCode,
                ChemicalName = filter.ChemicalName,
                SubCategoryCode = filter.SubCategoryCode,
                SubCategoryName = filter.SubCategoryName,
                Quantity = filter.Quantity,
                Unit = filter.Unit,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDyeingProcessChemicalQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingProcessChemicalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDyeingProcessChemicalCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingProcessChemicalCommand { Id = id }));
        }
    }
}