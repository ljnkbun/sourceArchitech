using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.DCTemplateDetail;
using Shopfloor.IED.Application.Command.DCTemplateDetails;
using Shopfloor.IED.Application.Parameters.DCTemplateDetails;
using Shopfloor.IED.Application.Query.DCTemplateDetails;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DCTemplateDetailController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DCTemplateDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetDCTemplateDetailsQuery()
            {
                DCTemplateTaskId = filter.DCTemplateTaskId,
                ChemicalCode = filter.ChemicalCode,
                ChemicalName = filter.ChemicalName,
                Unit = filter.Unit,
                Value = filter.Value,
                LineNumber = filter.LineNumber,
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
            return Ok(await Mediator.Send(new GetDCTemplateDetailQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDCTemplateDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDCTemplateDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteDCTemplateDetailCommand { Id = id }));
        }
    }
}