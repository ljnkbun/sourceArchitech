using Microsoft.AspNetCore.Mvc;
using Shopfloor.Production.Application.Command.FPPOOutputDetails;
using Shopfloor.Production.Application.Parameters.FPPOOutputDetails;
using Shopfloor.Production.Application.Query.FPPOOutputDetails;

namespace Shopfloor.Production.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FPPOOutputDetailController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FPPOOutputDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetFPPOOutputDetailsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                SearchTerm = filter.SearchTerm,
                OrderBy = filter.OrderBy,

                Code = filter.Code,
                Name = filter.Name,
                FPPOOutputId = filter.FPPOOutputId,
                PlannedQty = filter.PlannedQty,
                MadeQty = filter.MadeQty,
                BalanceQty = filter.BalanceQty,
                Size = filter.Size,
                Color = filter.Color,

                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFPPOOutputDetailQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFPPOOutputDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateFPPOOutputDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFPPOOutputDetailCommand { Id = id }));
        }
    }
}
