using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DyeingTBRCValues;
using Shopfloor.IED.Application.Parameters.DyeingTBRCValues;
using Shopfloor.IED.Application.Query.DyeingTBRCValues;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DyeingTBRCValueController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DyeingTBRCValueParameter filter)
        {
            return Ok(await Mediator.Send(new GetDyeingTBRCValuesQuery()
            {
                DyeingTBRChemicalId = filter.DyeingTBRChemicalId,
                DyeingTBRVersionId = filter.DyeingTBRVersionId,
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
            return Ok(await Mediator.Send(new GetDyeingTBRCValueQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDyeingTBRCValueCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDyeingTBRCValueCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDyeingTBRCValueCommand { Id = id }));
        }
    }
}