using Microsoft.AspNetCore.Mvc;
using Shopfloor.IED.Application.Command.KnittingYarns;
using Shopfloor.IED.Application.Parameters.KnittingYarns;
using Shopfloor.IED.Application.Query.KnittingYarns;

namespace Shopfloor.IED.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class KnittingYarnController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] KnittingYarnParameter filter)
        {
            return Ok(await Mediator.Send(new GetKnittingYarnsQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                KnittingIEDId = filter.KnittingIEDId,
                LineNumber = filter.LineNumber,
                WFXYarnId = filter.WFXYarnId,
                YarnName = filter.YarnName,
                YarnCode = filter.YarnCode,
                Color = filter.Color,
                YarnRatio = filter.YarnRatio,
                Weight = filter.Weight,
                Wastage = filter.Wastage,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetKnittingYarnQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateKnittingYarnsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/v1/<controller>/1
        [HttpPost("{knittingIEDId}")]
        public async Task<IActionResult> Post(int knittingIEDId, CreateKnittingYarnsCommand command)
        {
            if (knittingIEDId != command.KnittingIEDId) 
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>
        [HttpPut()]
        public async Task<IActionResult> Put(UpdateKnittingYarnCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/1
        [HttpPut("{knittingIEDId}")]
        public async Task<IActionResult> Put(int knittingIEDId, UpdateKnittingYarnsCommand command)
        {
            if (knittingIEDId != command.KnittingIEDId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteKnittingYarnCommand { Id = id }));
        }
    }
}
