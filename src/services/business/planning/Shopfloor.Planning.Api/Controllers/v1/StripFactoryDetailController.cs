using Microsoft.AspNetCore.Mvc;
using Shopfloor.Planning.Application.Command.StripFactoryDetails;
using Shopfloor.Planning.Application.Parameters.StripFactoryDetails;
using Shopfloor.Planning.Application.Query.StripFactoryDetails;


namespace Shopfloor.Planning.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StripFactoryDetailController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StripFactoryDetailParameter filter)
        {
            return Ok(await Mediator.Send(new GetStripFactoryDetailsQuery()
            {
                StripFactoryId = filter.StripFactoryId,
                PorDetailId = filter.PorDetailId,
                Size = filter.Size,
                Color = filter.Color,
                Quantity = filter.Quantity,
                RemainingQuantity = filter.RemainingQuantity,
                TypePORDetail = filter.TypePORDetail,
                UOM = filter.UOM,
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration
            }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetStripFactoryDetailQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateStripFactoryDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateStripFactoryDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteStripFactoryDetailCommand { Id = id }));
        }
    }
}
