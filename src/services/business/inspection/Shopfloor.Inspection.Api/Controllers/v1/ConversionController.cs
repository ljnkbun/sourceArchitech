using Microsoft.AspNetCore.Mvc;
using Shopfloor.Inspection.Application.Command.Conversions;
using Shopfloor.Inspection.Application.Parameters.Conversions;
using Shopfloor.Inspection.Application.Query.Conversions;

namespace Shopfloor.Inspection.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ConversionController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ConversionParameter filter)
        {
            return Ok(await Mediator.Send(new GetConversionsQuery()
            {
                Value = filter.Value,

                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Code = filter.Code,
                Name = filter.Name,
                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetConversionQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateConversionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateConversionCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteConversionCommand { Id = id }));
        }
    }
}
