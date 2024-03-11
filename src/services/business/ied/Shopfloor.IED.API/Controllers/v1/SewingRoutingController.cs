using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.SewingRoutings;
using Shopfloor.IED.Application.Parameters.SewingRoutings;
using Shopfloor.IED.Application.Query.SewingRoutings;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SewingRoutingController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SewingRoutingParameter filter)
        {
            return Ok(await Mediator.Send(new GetSewingRoutingsQuery()
            {
                SewingIEDId = filter.SewingIEDId,
                WFXProcessCode = filter.WFXProcessCode,
                WFXProcessName = filter.WFXProcessName,
                WFXOperationCode = filter.WFXOperationCode,
                WFXOperationName = filter.WFXOperationName,
                LineNumber = filter.LineNumber,
                SMV = filter.SMV,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Deleted = filter.Deleted,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSewingRoutingQuery { Id = id }));
        }

        // GET api/v1/<controller>/Export
        [HttpGet("Export/{id}")]
        public async Task<IActionResult> Export(int id)
        {
            return await Mediator.Send(new GetSewingLayoutExcelQuery { Id = id });
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateSewingRoutingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>/1
        [HttpPost("{sewingIEDId}")]
        public async Task<IActionResult> Post(int sewingIEDId, CreateSewingRoutingsCommand command)
        {
            if (sewingIEDId != command.SewingIEDId) 
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>
        [HttpPut()]
        public async Task<IActionResult> Put(UpdateSewingRoutingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/1
        [HttpPut("{sewingIEDId}")]
        public async Task<IActionResult> Put(int sewingIEDId, UpdateSewingRoutingsCommand command)
        {
            if (sewingIEDId != command.SewingIEDId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSewingRoutingCommand { Id = id }));
        }
    }
}
