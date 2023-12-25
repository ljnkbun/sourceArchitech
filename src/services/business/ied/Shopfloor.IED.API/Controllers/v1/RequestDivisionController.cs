using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.RequestDivisions;
using Shopfloor.IED.Application.Parameters.RequestDivisions;
using Shopfloor.IED.Application.Query.RequestDivisions;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RequestDivisionController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestDivisionParameter filter)
        {
            return Ok(await Mediator.Send(new GetRequestDivisionsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                RequestId = filter.RequestId,
                DivisionId = filter.DivisionId,
                DivisionCode = filter.DivisionCode,
                DivisionName = filter.DivisionName,
                LineNumber = filter.LineNumber,
                Status = filter.Status,
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
            return Ok(await Mediator.Send(new GetRequestDivisionQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRequestDivisionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRequestDivisionCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRequestDivisionCommand { Id = id }));
        }
    }
}
