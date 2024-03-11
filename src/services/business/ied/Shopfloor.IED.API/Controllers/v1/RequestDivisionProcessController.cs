using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.RequestDivisionProcesses;
using Shopfloor.IED.Application.Parameters.RequestDivisionProcesses;
using Shopfloor.IED.Application.Query.RequestDivisionProcesses;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RequestDivisionProcessController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestDivisionProcessParameter filter)
        {
            return Ok(await Mediator.Send(new GetRequestDivisionProcessesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                RequestDivisionId = filter.RequestDivisionId,
                ProcessId = filter.ProcessId,
                ProcessCode = filter.ProcessCode,
                ProcessName = filter.ProcessName,
                LineNumber = filter.LineNumber,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRequestDivisionProcessQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRequestDivisionProcessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateRequestDivisionProcessCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRequestDivisionProcessCommand { Id = id }));
        }
    }
}
